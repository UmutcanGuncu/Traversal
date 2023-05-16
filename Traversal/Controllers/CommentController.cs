using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using System;
using System.Threading.Tasks;

namespace Traversal.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());
        private readonly UserManager<AppUser> _userManager;

        public CommentController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate=DateTime.Now;
            comment.Status = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
