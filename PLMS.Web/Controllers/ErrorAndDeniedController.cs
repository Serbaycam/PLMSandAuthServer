using Microsoft.AspNetCore.Mvc;

namespace PLMS.Web.Controllers
{
    public class ErrorAndDeniedController : Controller
    {
        #region AccessDenied
        public IActionResult AccessDenied()
        {
            return View();
        }
        #endregion
        #region ErrorPage
        public IActionResult Error()
        {
            return View();
        }
        #endregion
    }
}
