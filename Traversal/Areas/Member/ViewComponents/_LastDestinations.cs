using BusinnesLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.ViewComponents
{
    public class _LastDestinations:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values =_destinationService.GetLast4Destinations();
            return View(values);
        }
    }
}
