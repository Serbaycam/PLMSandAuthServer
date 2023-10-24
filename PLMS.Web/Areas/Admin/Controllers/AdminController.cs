namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AdminController : Controller
    {
        public IActionResult AdminIndex()
        {
            return View();
        }
    }
}
