using Microsoft.AspNetCore.Authorization;

namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Route("Account/[controller]/[action]")]
    public class AccountController : Controller
    {

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return PartialView(new AuthIdentityUserLoginDto());
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return PartialView(new AuthIdentityUserRegisterDto());
        }
    }
}
