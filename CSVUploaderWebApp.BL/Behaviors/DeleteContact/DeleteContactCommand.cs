using MediatR;

namespace CSVUploaderWebApp.BL.Behaviors.DeleteContact;

public class DeleteContactCommand: IRequest<Unit>
{
    public int Id { get; set; }
}