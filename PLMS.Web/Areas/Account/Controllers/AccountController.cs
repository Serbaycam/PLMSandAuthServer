namespace PLMS.Web.Areas.Account.Controllers
{
    [Area("Account")]
    [Authorize]
    public class AccountController(IMapper mapper, IAuthIdentityMemberService identityMemberService, IToastNotification toastNotification) : Controller
    {
        private readonly IAuthIdentityMemberService _identityMemberService = identityMemberService;
        private readonly IMapper _mapper = mapper;
        private readonly IToastNotification _toastNotification = toastNotification;
        private string UserName => User.Identity.Name;



        #region User Profile
        public async Task<IActionResult> UserProfile()
        {
            AuthIdentityUserDto authIdentityUserDto = await _identityMemberService.GetUserDtoByUserNameAsync(UserName);
            return View(authIdentityUserDto);
        }
        #endregion

        #region Login Methods
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View(new AuthIdentityUserLoginDto());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(AuthIdentityUserLoginDto authIdentityUserLoginDto, string returnUrl = null)
        {
            returnUrl ??= "/Home/Index";
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
        #endregion

        #region Register Methods
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
        #endregion

        #region Logout Method
        public async Task<IActionResult> Logout()
        {
            await _identityMemberService.Logout();
            _toastNotification.AddSuccessToastMessage("Logout successfully");
            return RedirectToAction(nameof(Login));
        }
        #endregion

    }
}
