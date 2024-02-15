using NToastNotify;

namespace PLMS.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "MasterAdmin,Admin")]
    public class AdminController(IAuthIdentityUserService identityUserService, IAuthIdentityMemberService memberService, IToastNotification toastNotification) : Controller
    {
        private readonly IAuthIdentityUserService _identityUserService = identityUserService;
        private readonly IAuthIdentityMemberService _memberService = memberService;
        private readonly IToastNotification _toastNotification = toastNotification;

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            return View(await _identityUserService.GetAllUsersAsync());
        }

        [HttpGet]
        public async Task<IActionResult> UserModify(string id)
        {
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserModify(AuthIdentityUserDto userDto)
        {
            return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserDelete(string id)
        {
            AuthIdentityUser user = await _memberService.GetUserByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _memberService.DeleteUserByUserAsync(user);
                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("User Deleted");
                    return RedirectToAction("UserList");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        _toastNotification.AddErrorToastMessage(item.Description);

                    }
                    return RedirectToAction("UserList");
                }
            }
            else
            {
                _toastNotification.AddErrorToastMessage("User Not Found");
                return RedirectToAction("UserList");
            }

        }
    }
}
