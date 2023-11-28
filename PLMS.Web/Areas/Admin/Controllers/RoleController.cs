namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager;
        public RoleController(RoleManager<AuthIdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Roles()
        {
            List<AuthIdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> RoleDelete(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> RoleDelete(AuthIdentityRole role)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> RoleModify(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> RoleModify(AuthIdentityRole role)
        {
            throw new NotImplementedException();
        }
    }
}
