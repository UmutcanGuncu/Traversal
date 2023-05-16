using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.ViewComponents
{
    public class _MemberStatistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
