 using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal.ViewComponents
{
    public class _CommentList:ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        Context context = new Context();
        public IViewComponentResult Invoke(int id)
        {
            ViewBag.Count=context.Comments.Where(x=> x.Id==id).Count();
            var values = commentManager.GetListCommentWithDestinationAndUser(id);
            
            return View(values);
        } 
    }
}
