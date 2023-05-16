using BusinnesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinations : Controller
    {

        private readonly IDestinationService _destinationService;

        public LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.GetLast4Destinations();
            return View(values);
        }
    }
}
