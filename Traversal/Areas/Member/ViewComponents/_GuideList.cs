using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.ViewComponents
{
    public class _GuideList:ViewComponent
    {
        GuideManager guideManager = new GuideManager(new EFGuideDAL());
        public IViewComponentResult Invoke()
        {
            var values=guideManager.TGetList();
            return View(values);
        }
    }
}
