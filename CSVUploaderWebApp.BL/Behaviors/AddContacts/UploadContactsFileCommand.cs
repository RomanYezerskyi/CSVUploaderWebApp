using MediatR;
using Microsoft.AspNetCore.Http;

namespace CSVUploaderWebApp.BL.Behaviors.AddContacts;

public class UploadContactsFileCommand: IRequest<Unit>
{
    public IFormFile File { get; set; }
}