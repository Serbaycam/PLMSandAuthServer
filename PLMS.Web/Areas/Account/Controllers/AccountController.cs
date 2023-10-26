using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace PLMS.Web.Areas.Account.Controllers
{
	[Area("Account")]
	[Route("Account/[controller]/[action]")]
	public class AccountController : Controller
	{
		private readonly IAuthIdentityMemberService _identityMemberService;
		private readonly IMapper _mapper;

		public AccountController(IMapper mapper, IAuthIdentityMemberService identityMemberService)
		{
			_mapper = mapper;
			_identityMemberService = identityMemberService;
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
				}
				return View(authIdentityUserRegisterDto);
			}
			ViewBag.Message = "Register completed successfuly";
			return RedirectToAction(nameof(Login));
		}


		public async Task Logout()
		{
			await _identityMemberService.Logout();
		}
	}
}
