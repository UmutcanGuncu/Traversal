using BusinnesLayer.Abstract;
using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
           
        }

        public IActionResult Index() 
        {
            var commentList=_commentService.GetListCommentWithDestination();
            return View(commentList);
        }
        public IActionResult DeleteComment(int id) 
        {
            var comment=_commentService.TGetById(id);
            _commentService.TDelete(comment);
            return RedirectToAction("Index","Comment","Admin");
        }
    }
}
