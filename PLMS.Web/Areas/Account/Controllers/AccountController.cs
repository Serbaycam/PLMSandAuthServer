﻿using Microsoft.AspNetCore.Authorization;

namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]

    public class AccountController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return PartialView();
        }
    }
}
