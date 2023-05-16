using Microsoft.AspNetCore.Mvc;

namespace Traversal.ViewComponents
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            return View();
        }
    }
}
