using CSVUploaderWebApp.DL.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.BL.Behaviors.DeleteContact;

public class DeleteContactHandler: IRequestHandler<DeleteContactCommand, Unit>
{
    private readonly AppDbContext _context; 
    
    public DeleteContactHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(c=> c.Id == request.Id, cancellationToken);

        if (contact != null)
        {
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync(cancellationToken);
        }

        return Unit.Value;
    }
}