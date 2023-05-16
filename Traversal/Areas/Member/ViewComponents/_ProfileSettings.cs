using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.ViewComponents
{
    public class _ProfileSettings:ViewComponent
    { 
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
