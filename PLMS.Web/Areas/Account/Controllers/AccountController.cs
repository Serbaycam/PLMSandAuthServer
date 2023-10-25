using Microsoft.AspNetCore.Authorization;

namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("Account/[controller]/[action]")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View(new AuthIdentityUserLoginDto());
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new AuthIdentityUserRegisterDto());
        }
    }
}
