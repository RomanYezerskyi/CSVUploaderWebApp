using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CSVUploaderWebApp.BL.Constants;
using CSVUploaderWebApp.BL.DTOs;
using CSVUploaderWebApp.BL.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CSVUploaderWebApp.BL.Services;

public class CsvReaderService: ICsvReaderService
{
    public List<ContactDataJsonDto> ReadCsv(IFormFile file)
    {
        if (file.ContentType != "text/csv") throw new Exception(ErrorMessage.BadFileTypeError);
        
        using var reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture));
        return csv.GetRecords<ContactDataJsonDto>().ToList();
    }
}