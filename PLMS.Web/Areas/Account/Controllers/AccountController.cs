using AuthIdentity.Core.DTOs;
using PLMS.Web.Controllers;

namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthIdentityMemberService _identityMemberService;
        private readonly IMapper _mapper;
        private readonly IToastNotification _toastNotification;

        public AccountController(IMapper mapper, IAuthIdentityMemberService identityMemberService, IToastNotification toastNotification)
        {
            _mapper = mapper;
            _identityMemberService = identityMemberService;
            _toastNotification = toastNotification;
        }

        private string userName => User.Identity.Name;

        public IActionResult Index()
        {
            return View();
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View(new AuthIdentityUserLoginDto());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AuthIdentityUserLoginDto authIdentityUserLoginDto,string returnUrl=null)
        {
            returnUrl = returnUrl ?? "/Home/Index";
            var (isSuccess, error) = await _identityMemberService.LoginAsync(authIdentityUserLoginDto);
            if (!isSuccess)
            {
                _toastNotification.AddErrorToastMessage(error);
                return View(authIdentityUserLoginDto);
            }
            else
            {
                _toastNotification.AddSuccessToastMessage("Login successfully");
                return Redirect(returnUrl);
            }



        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View(new AuthIdentityUserRegisterDto());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(AuthIdentityUserRegisterDto authIdentityUserRegisterDto)
        {
            var (isSuccess, errors) = await _identityMemberService.RegisterUserByUserDtoAsync(authIdentityUserRegisterDto);
            if (!isSuccess)
            {
                foreach (IdentityError error in errors)
                {
                    _toastNotification.AddErrorToastMessage(error.Description);
                }
                return View();
            }
            _toastNotification.AddSuccessToastMessage("Register completed successfuly");
            return RedirectToAction(nameof(Login));
        }


        public async Task<IActionResult> Logout()
        {
            await _identityMemberService.Logout();
            _toastNotification.AddSuccessToastMessage("Logout successfully");
            return RedirectToAction(nameof(Login));
        }
    }
}
