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
    }
}
