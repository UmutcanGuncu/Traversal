using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using System.Threading.Tasks;
using Traversal.Areas.Admin.Models;
using Traversal.Models;

namespace Traversal.Controllers
{
    [AllowAnonymous]
    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange",new
            {
                userId=user.Id,
                token=passwordResetToken
            },HttpContext.Request.Scheme);
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Umutcan", "umutcangs62@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); // gönderen kişi
            MailboxAddress mailboxAddressTo = new MailboxAddress("Kullanıcı", model.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Şifre Değişiklik Talebi";
            SmtpClient smtpClient= new SmtpClient();
            smtpClient.Connect("smtp.gmail.com", 587, false);
            smtpClient.Authenticate("umutcangs62@gmail.com", "iesomkoqccqcxdcm");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();

        }
        [HttpGet]
        public IActionResult ResetPassword(string userId,string token)
        {
            TempData["userId"]=userId; 
            TempData["token"]=token;
            return View();

        }
        [HttpPost]
        public async Task <IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            var userId = TempData["userId"];
            var token = TempData["token"];
            if(userId == null||token==null) 
            {
                
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var result = await _userManager.ResetPasswordAsync(user,token.ToString(),model.NewPassword);
            if(result.Succeeded) 
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}
