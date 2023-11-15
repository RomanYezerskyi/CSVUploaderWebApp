using CSVUploaderWebApp.BL.DTOs;
using CSVUploaderWebApp.DL.Models;
using MediatR;

namespace CSVUploaderWebApp.BL.Behaviors.GetContacts;

public class GetContactsQuery: IRequest<List<ContactData>>
{
}