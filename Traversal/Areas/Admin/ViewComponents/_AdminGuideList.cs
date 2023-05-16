using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Admin.ViewComponents
{
    public class _AdminGuideList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
