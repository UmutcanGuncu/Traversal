using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal.CQRS.Commands.DestinationCommand;
using Traversal.CQRS.Handlers.DestinationHandlers;
using Traversal.CQRS.Queries.DestinationQueries;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _queryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler queryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _queryHandler = queryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _queryHandler.Handle();
            return View(values);
        }
        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }
        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command); 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand createDestinationCommand)
        {
            _createDestinationCommandHandler.Handle(createDestinationCommand);
            return RedirectToAction("Index", "Default");

        }
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle( new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
