namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
