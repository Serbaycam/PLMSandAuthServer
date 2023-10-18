using Microsoft.AspNetCore.Mvc;

namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
