using CSVUploaderWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using CSVUploaderWebApp.BL.Behaviors.AddContacts;
using CSVUploaderWebApp.BL.Behaviors.DeleteContact;
using CSVUploaderWebApp.BL.Behaviors.GetContacts;
using CSVUploaderWebApp.BL.Behaviors.UpdateContact;
using MediatR;

namespace CSVUploaderWebApp.Controllers
{
    public class DataController : Controller
    {
        private readonly ILogger<DataController> _logger;
        private readonly IMediator _mediator;

        public DataController(ILogger<DataController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetContactsQuery()));
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadFile(UploadContactsFileCommand command)
        {
            return Json(await _mediator.Send(command));
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            return Json(await _mediator.Send(command));
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var command = new DeleteContactCommand { Id = id };
            await _mediator.Send(command);

            return Ok();
        }
    }
}