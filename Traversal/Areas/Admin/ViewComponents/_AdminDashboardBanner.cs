using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents
{
    public class _AdminDashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
