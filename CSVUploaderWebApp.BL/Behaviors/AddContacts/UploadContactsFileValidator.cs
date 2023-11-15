using CSVUploaderWebApp.BL.Constants;
using FluentValidation;

namespace CSVUploaderWebApp.BL.Behaviors.AddContacts;

public class UploadContactsFileValidator: AbstractValidator<UploadContactsFileCommand>
{
    public UploadContactsFileValidator()
    {
        RuleFor(command => command.File)
            .NotEmpty().WithMessage(ErrorMessage.EmptyFileError);
    }
}