using CSVUploaderWebApp.BL.DTOs;
using CSVUploaderWebApp.DL.DataContext;
using CSVUploaderWebApp.DL.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSVUploaderWebApp.BL.Behaviors.GetContacts;

public class GetContactsHandler: IRequestHandler<GetContactsQuery, List<ContactData>>
{
    private readonly AppDbContext _context;
    
    public GetContactsHandler(AppDbContext context)
    {
        _context = context;
    }
        
    public async Task<List<ContactData>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Contacts.ToListAsync(cancellationToken);
    }
}