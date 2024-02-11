namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="MasterAdmin,Admin")]
    public class AdminController(IAuthIdentityUserService identityUserService) : Controller
    {
        private readonly IAuthIdentityUserService _identityUserService = identityUserService;
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            return View(await _identityUserService.GetAllUsersAsync());
        }
    }
}
