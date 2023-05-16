using BusinnesLayer.Abstract.AbstractUnitOfWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Traversal.Areas.Admin.Models;

namespace Traversal.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles ="Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountViewModel model)
        {
            var valueSender = _accountService.TGetById(model.SenderId); // gönderici id'ye göre verileri getirecek
            var valueReceiver = _accountService.TGetById(model.ReceiverId);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance+=model.Amount;
            List<Account> modifiedAccounts = new List<Account>()
            {
                valueSender,
                valueReceiver
            };

            _accountService.TMultiUpdate(modifiedAccounts);
            return RedirectToAction("Index","Default");
        }
    }
}
