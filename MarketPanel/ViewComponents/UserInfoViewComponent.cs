using MarketPanel.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarketPanel.ViewComponents;

public class UserInfoViewComponent : ViewComponent
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserInfoViewComponent(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        string email = "";

        if (_signInManager.IsSignedIn(HttpContext.User))
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            email = user.Email;
        }

        return View("Default", email);
    }
}
