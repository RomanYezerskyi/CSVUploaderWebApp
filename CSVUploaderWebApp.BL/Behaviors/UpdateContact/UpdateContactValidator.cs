using CSVUploaderWebApp.BL.Constants;
using CSVUploaderWebApp.DL.DataContext;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.BL.Behaviors.UpdateContact;

public class UpdateContactValidator: AbstractValidator<UpdateContactCommand>
{
    public UpdateContactValidator(AppDbContext context)
    {
        RuleFor(command => command.Id)
            .Must(id => id != 0)
            .WithMessage(ErrorMessage.BadContactIdError)
            .MustAsync(async (id, cancellationToken) =>
            {
                return await context.Contacts.AnyAsync(c => c.Id == id, cancellationToken);
            })
            .WithMessage(ErrorMessage.ContactNotFoundError);

        RuleFor(command => command.Name)
            .NotEmpty()
            .NotNull()
            .WithMessage(ErrorMessage.NameRequiredError);

        RuleFor(command => command.Phone)
            .NotEmpty()
            .NotNull()
            .WithMessage(ErrorMessage.PhoneRequiredError)
            .MinimumLength(10)
            .WithMessage(ErrorMessage.PhoneLenghtError);

        RuleFor(command => command.DateOfBirth)
            .NotEmpty()
            .NotNull()
            .WithMessage(ErrorMessage.DateOfBirthRequiredError);
        
        RuleFor(command => command.Salary)
            .Must(s => s != 0)
            .NotEmpty()
            .NotNull()
            .WithMessage(ErrorMessage.SalaryError);
    }
}