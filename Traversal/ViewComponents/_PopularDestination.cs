using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _PopularDestination:ViewComponent
    {
        DestinationManager destinationManager = new DestinationManager(new EFDestinationDal()); 
        public IViewComponentResult Invoke()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }
    }
}
