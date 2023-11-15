using CSVUploaderWebApp.BL.DTOs;
using Microsoft.AspNetCore.Http;

namespace CSVUploaderWebApp.BL.Interfaces;

public interface ICsvReaderService
{
    List<ContactDataJsonDto> ReadCsv(IFormFile file);
}