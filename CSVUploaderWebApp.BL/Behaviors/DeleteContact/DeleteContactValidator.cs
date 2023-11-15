using CSVUploaderWebApp.BL.Constants;
using CSVUploaderWebApp.DL.DataContext;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.BL.Behaviors.DeleteContact;

public class DeleteContactValidator: AbstractValidator<DeleteContactCommand>
{
    public DeleteContactValidator(AppDbContext context)
    {
        RuleFor(command => command.Id)
            .Must(id => id != 0)
            .WithMessage(ErrorMessage.BadContactIdError)
            .MustAsync(async (id, cancellationToken) =>
            {
                return await context.Contacts.AnyAsync(c => c.Id == id, cancellationToken);
            })
            .WithMessage(ErrorMessage.ContactNotFoundError);
    }
}