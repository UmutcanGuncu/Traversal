using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequest mailRequest)
        {
            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Umutcan", "umutcangs62@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom); // gönderen kişi
            MailboxAddress mailboxAddressTo = new MailboxAddress("Ferhat Paşa",mailRequest.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody= mailRequest.Body;
            mimeMessage.Body=bodyBuilder.ToMessageBody();
            
            mimeMessage.Subject=mailRequest.Subject;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Connect("smtp.gmail.com",587,false);
            smtpClient.Authenticate("umutcangs62@gmail.com", "iesomkoqccqcxdcm");
            smtpClient.Send(mimeMessage);
            smtpClient.Disconnect(true);
            return View();
        }
    }
}
