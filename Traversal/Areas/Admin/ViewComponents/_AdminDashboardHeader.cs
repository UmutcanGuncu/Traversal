using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents
{
    public class _AdminDashboardHeader:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
