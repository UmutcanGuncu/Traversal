using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _SubAbout : ViewComponent
    {
        SubaboutManager _manager = new SubaboutManager(new EFSubaboutDal());
        public IViewComponentResult Invoke()
        {
            var values = _manager.TGetList();
            return View(values);
        }
    }
}
