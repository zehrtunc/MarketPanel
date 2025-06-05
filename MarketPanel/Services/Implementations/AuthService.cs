using MarketPanel.Models.Entities;
using MarketPanel.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace MarketPanel.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterAsync(string email, string password, string name, string surname)
    {
        var existingUser = await _userManager.FindByEmailAsync(email);
        // zaten o mailde bir user varsa register durumunu engelle
        if (existingUser != null)
        {
            return false;
        }
        var user = new ApplicationUser()
        {
            UserName = email,
            Email = email,
            Name = name,
            Surname = surname
        };

        //Db`ye user eklenir
        var result = await _userManager.CreateAsync(user, password);
        return result.Succeeded;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        //Db`den mevcut emaile sahip user getirilir
        var user = await _userManager.FindByEmailAsync(email);
        if(user == null)
        {
            return false;
        }

        //Password kontrolu
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);

        //Password yanlis ise
        if(!result.Succeeded)
        {
            return false; //Actiona sifre yanlis oldugu icin false gonderilir, Actionda hata mesaji bastirilacak
        }


        await _signInManager.SignInAsync(user, isPersistent: false);

        return true;
    }

    public async Task LogoutAsync()
    {
        await _signInManager.SignOutAsync();
    }
}
