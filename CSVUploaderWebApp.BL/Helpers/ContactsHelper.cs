using CSVUploaderWebApp.BL.DTOs;
using CSVUploaderWebApp.DL.Models;

namespace CSVUploaderWebApp.BL.Helpers;

public static class ContactsHelper
{
    public static IEnumerable<ContactData> ConvertToModel(this List<ContactDataJsonDto> data)
    {
        return data.Select(d => d.ConvertToModel());
    }
    
    public static ContactData ConvertToModel(this ContactDataJsonDto data)
    {
        var model = new ContactData()
        {
            Married = data.Married,
            Name = data.Name,
            Phone = data.Phone,
            Salary = data.Salary,
        };
        
        if (DateTime.TryParse(data.DateOfBirth, out var dateValue))
        {
            model.DateOfBirth = dateValue;
        }

        return model;
    }
}