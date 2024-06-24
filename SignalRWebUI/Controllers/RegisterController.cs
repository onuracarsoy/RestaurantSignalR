using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Models.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			var appUser = new AppUser
			{
				FirstName = registerDto.FirstName,
				LastName = registerDto.LastName,
				UserName = registerDto.UserName
			};

			var result = await _userManager.CreateAsync(appUser, registerDto.Password);
			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Login");
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View();
		}

	}
}

