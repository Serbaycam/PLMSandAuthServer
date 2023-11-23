using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {
            AuthIdentityUserDto authIdentityUserDto = await _identityMemberService.GetUserDtoByUserNameAsync(UserName);
            return View(authIdentityUserDto);
        }
        #endregion

        #region Login Method
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
            if (!ModelState.IsValid)
                return View(authIdentityUserLoginDto);
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

        #region Register Method
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
            if (!ModelState.IsValid)
                return View(authIdentityUserRegisterDto);
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
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _identityMemberService.LogoutAsync();
            _toastNotification.AddSuccessToastMessage("Logout successfully");
            return RedirectToAction(nameof(Login));
        }
        #endregion

        #region Password Change Method
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View(new AuthIdentityUserChangePasswordDto());
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(AuthIdentityUserChangePasswordDto authIdentityUserChangePasswordDto)
        {
            if (!ModelState.IsValid)
                return View(authIdentityUserChangePasswordDto);
            AuthIdentityUser currentUser = await _identityMemberService.GetUserByNameAsync(User.Identity.Name);
            bool checkOlPassword = await _identityMemberService.CheckPasswordAsync(currentUser, authIdentityUserChangePasswordDto.OldPassword);
            if (!checkOlPassword)
            {
                _toastNotification.AddErrorToastMessage("Old Password is not correct");
                return View(authIdentityUserChangePasswordDto);
            }
            IdentityResult passwordChangeResult = await _identityMemberService.ChangePasswordAsync(currentUser, authIdentityUserChangePasswordDto.OldPassword, authIdentityUserChangePasswordDto.NewPassword);
            if (!passwordChangeResult.Succeeded)
            {
                foreach (IdentityError error in passwordChangeResult.Errors)
                {
                    _toastNotification.AddErrorToastMessage(error.Description);
                }
                return View(authIdentityUserChangePasswordDto);
            }
            _toastNotification.AddSuccessToastMessage("Password Change Successfully.");
            await _identityMemberService.UpdateSecurityStampAsync(currentUser);
            await _identityMemberService.LogoutAsync();
            await _identityMemberService.LoginAsync(new AuthIdentityUserLoginDto { Email=currentUser.Email,Password=authIdentityUserChangePasswordDto.NewPassword,RememberMe=true});
            return View();
        }
        #endregion

        #region Email Change Method
        [HttpGet]
        public IActionResult ChangeEmail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangeEmail(string xx)
        {
            return View();
        }
        #endregion

    }
}
