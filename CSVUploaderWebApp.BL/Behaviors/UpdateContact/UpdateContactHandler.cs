using CSVUploaderWebApp.DL.DataContext;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.BL.Behaviors.UpdateContact;

public class UpdateContactHandler: IRequestHandler<UpdateContactCommand, Unit>
{
    private readonly AppDbContext _context;
    
    public UpdateContactHandler(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = await _context.Contacts.FirstAsync(c => c.Id == request.Id, cancellationToken);
        
        contact.Name = request.Name;
        contact.Phone = request.Phone;
        contact.Salary = request.Salary;
        contact.DateOfBirth = request.DateOfBirth;
        contact.Married = request.Married;

        _context.Contacts.Update(contact);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}