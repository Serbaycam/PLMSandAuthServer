namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "MasterAdmin,Admin")]
    public class RoleController(RoleManager<AuthIdentityRole> roleManager, IAuthIdentityRoleService roleService, IToastNotification toastNotification) : Controller
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IAuthIdentityRoleService _roleService = roleService;
        private readonly IToastNotification _toastNotification = toastNotification;

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            return View(await _roleService.GetRoleDtoListAllRolesAsync());
        }
        [HttpGet]
        public async Task<IActionResult> RoleAdd()
        {
            return await Task.Run(View);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(AuthIdentityRoleDto dto)
        {
            var result = await _roleService.CreateRoleAsync(dto);
            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Successfully Role Added");
                return RedirectToAction(nameof(Roles));
            }
            else
            {
                foreach (IdentityError item in result.Errors)
                {
                    _toastNotification.AddErrorToastMessage(item.Description);
                }
                return View(dto);
            }

        }

        [HttpGet]
        public async Task<IActionResult> RoleModify(string id)
        {
            AuthIdentityRoleDto role = await _roleService.GetRoleDtoByIdAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> RoleModify(AuthIdentityRoleDto role)
        {
            IdentityResult result = await _roleService.ModifyRoleAsync(role);
            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Successfully Role Modified");
                return RedirectToAction(nameof(Roles));
            }
            else
            {
                foreach (IdentityError item in result.Errors)
                {
                    _toastNotification.AddErrorToastMessage(item.Description);
                }
                return View(role);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RoleDelete(string id)
        {
            AuthIdentityRoleDto result = await _roleService.GetRoleDtoByIdAsync(id);
            IdentityResult identityResult = await _roleService.DeleteRoleAsync(result);
            if (identityResult.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Successfully Role Deleted");
                return RedirectToAction(nameof(Roles));
            }
            else
            {
                foreach (IdentityError item in identityResult.Errors)
                {
                    _toastNotification.AddErrorToastMessage(item.Description);
                }
                return RedirectToAction(nameof(Roles));
            }
        }
    }
}
