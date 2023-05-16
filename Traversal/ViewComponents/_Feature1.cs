using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _Feature1 : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
