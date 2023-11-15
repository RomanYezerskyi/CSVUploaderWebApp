namespace CSVUploaderWebApp.BL.Constants;

public static class ErrorMessage
{
    public const string EmptyFileError = "File path cannot be empty.";
    public const string BadFileTypeError = "File must have csv format";
    public const string BadContactIdError = "Bad contact id";
    public const string ContactNotFoundError = "Contact not found";
    public const string NameRequiredError = "Name filed is required";
    public const string PhoneRequiredError = "Phone filed is required";
    public const string PhoneLenghtError = "Phone min lenght 10";
    public const string DateOfBirthRequiredError = "Date of birth filed is required";
    public const string SalaryError = "Salary required";
}