using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _Statistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
