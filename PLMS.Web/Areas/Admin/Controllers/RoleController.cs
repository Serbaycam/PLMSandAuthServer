using NToastNotify;

namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController(RoleManager<AuthIdentityRole> roleManager, IAuthIdentityRoleService roleService, IToastNotification toastNotification) : Controller
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IAuthIdentityRoleService _roleService= roleService;
        private readonly IToastNotification _toastNotification = toastNotification;

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            List<AuthIdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        [HttpGet]
        public async Task<IActionResult> RoleAdd()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(AuthIdentityRoleAddDto dto)
        {
            var result = await _roleService.CreateRoleAsync(dto);
            if(result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("successfully Role Added");
                return RedirectToAction(nameof(Roles));
            }
            else
            {
                foreach(IdentityError item in result.Errors)
                {
                    _toastNotification.AddErrorToastMessage(item.Description);
                }
                return View(dto);
            }
            
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
