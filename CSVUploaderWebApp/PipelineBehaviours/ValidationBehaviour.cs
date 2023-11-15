using FluentValidation;
using MediatR;

namespace CSVUploaderWebApp.PipelineBehaviours;

public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken
    )
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);

        var validationResults =
            await Task.WhenAll(_validators.Select(i => i.ValidateAsync(context, cancellationToken)));
        
        if (validationResults.Any(i => !i.IsValid))
        {
            throw new ValidationException(validationResults.SelectMany(i => i.Errors));
        }
        
        return await next();
    }
}