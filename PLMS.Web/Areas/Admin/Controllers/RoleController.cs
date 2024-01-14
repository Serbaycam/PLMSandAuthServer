namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController(RoleManager<AuthIdentityRole> roleManager, IAuthIdentityRoleService roleService, IToastNotification toastNotification) : Controller
    {
        private readonly RoleManager<AuthIdentityRole> _roleManager = roleManager;
        private readonly IAuthIdentityRoleService _roleService = roleService;
        private readonly IToastNotification _toastNotification = toastNotification;

        [HttpGet]
        public async Task<IActionResult> Roles()
        {
            return View(await _roleService.GetAllRolesAsync());
        }
        [HttpGet]
        public async Task<IActionResult> RoleAdd()
        {
            return await Task.Run(View);
        }

        [HttpPost]
        public async Task<IActionResult> RoleAdd(AuthIdentityRoleAddDto dto)
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
            AuthIdentityRoleModifyDto role = await _roleService.GetRoleByIdForModifyAsync(id);
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> RoleModify(AuthIdentityRoleModifyDto role)
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
            AuthIdentityRoleDeleteDto result = await _roleService.GetRoleByIdForDeleteAsync(id);
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
