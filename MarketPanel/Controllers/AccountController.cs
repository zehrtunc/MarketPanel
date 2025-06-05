using MarketPanel.Models.ViewModels;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.Controllers;

public class AccountController : Controller
{
    private readonly IAuthService _authService;

	public AccountController(IAuthService authService)
	{
		_authService = authService;
	}

	[HttpGet]
	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterViewModel model)
	{
		if (!ModelState.IsValid) return View(model);

		var result = await _authService.RegisterAsync(model.Email, model.Password, model.Name, model.Surname);

		//user zaten kayitliysa, serviceden false gelir
		if (!result)
		{
			ModelState.AddModelError(string.Empty, "This e-mail already exists!");
			return View(model);
		}

		return RedirectToAction("Login", "Account");
	}

	[HttpGet]
	public IActionResult Login()
	{
		return View();	
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginViewModel model)
    {
		if (!ModelState.IsValid) return View(model);

		var result = await _authService.LoginAsync(model.Email, model.Password);

		if(!result)
		{
			ModelState.AddModelError(string.Empty, "Login failed! Please check the information again.");
			return View(model);
		}

		return RedirectToAction("Index", "Home");
    }

	[HttpPost]
	public async Task<IActionResult> Logout()
	{
		await _authService.LogoutAsync();
		return RedirectToAction("Login", "Account");
	}
}
