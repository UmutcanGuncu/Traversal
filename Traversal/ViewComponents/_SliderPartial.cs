using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _SliderPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
