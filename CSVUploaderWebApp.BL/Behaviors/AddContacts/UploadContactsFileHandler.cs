using CSVUploaderWebApp.BL.Behaviors.AddContacts;
using CSVUploaderWebApp.BL.Constants;
using CSVUploaderWebApp.BL.Helpers;
using CSVUploaderWebApp.BL.Interfaces;
using CSVUploaderWebApp.DL.DataContext;
using MediatR;

namespace CSVUploaderWebApp.BL.Behaviors.CvsData;

public class UploadContactsFileHandler: IRequestHandler<UploadContactsFileCommand, Unit>
{
    private readonly AppDbContext _context;
    private readonly ICsvReaderService _csvReaderService;
    
    public UploadContactsFileHandler(AppDbContext context, ICsvReaderService csvReaderService)
    {
        _context = context;
        _csvReaderService = csvReaderService;
    }
    
    public async Task<Unit> Handle(UploadContactsFileCommand request, CancellationToken cancellationToken)
    {
        var parsedData = _csvReaderService.ReadCsv(request.File).ConvertToModel();

        await _context.Contacts.AddRangeAsync(parsedData, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
            
        return Unit.Value;
    }
}