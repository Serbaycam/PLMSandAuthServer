namespace PLMS.Web.Areas.Account.Controllers
{
	[Area("Account")]
	[Route("Account/[controller]/[action]")]
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
		public IActionResult Login(AuthIdentityUserLoginDto authIdentityUserLoginDto)
		{
			return View(authIdentityUserLoginDto);
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
			if(!isSuccess)
			{
				foreach (IdentityError error in errors)
				{
					ModelState.AddModelError(String.Empty,error.Description);
                    _toastNotification.AddErrorToastMessage(error.Description);
                }
				return View();
			}
            _toastNotification.AddSuccessToastMessage("Register completed successfuly");
			return RedirectToAction(nameof(Login));
		}


		public async Task Logout()
		{
			await _identityMemberService.Logout();
		}
	}
}
