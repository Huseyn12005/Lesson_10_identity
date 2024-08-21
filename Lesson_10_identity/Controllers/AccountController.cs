using Lesson_10_identity.Entities.Concretes;
using Lesson_10_identity.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_10_identity.Controllers;


public class AccountController : Controller
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
         await _signInManager.SignOutAsync();
        return RedirectToAction("Login");
    }

    [HttpGet]
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVm model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user is null)
        {
            ModelState.AddModelError("All", "User movcud deyil");
            return View(model);
        }

        var password = await _userManager.CheckPasswordAsync(user, model.Password);

        if (!password)
        {
            ModelState.AddModelError("All", "Userin PAsswordu sehfdir");
            return View(model);
        }

        var email = await _userManager.IsEmailConfirmedAsync(user);

        if(!email)
        {
            ModelState.AddModelError("All", "Email tesdiq edilmeyib");
            return View(model);
        }



        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRememberMe, false);

        if (result.Succeeded)
            return RedirectToAction("Index", "Home");

        ModelState.AddModelError("All", "Login Prosesi Shef oldu");
        return View(model);

    }


    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVm model)
    {
        if (!ModelState.IsValid)
            return View(model);

        AppUser appUser = new AppUser()
        {
            UserName = model.Email,
            Email = model.Email,
            Name = model.Name,
        };

        var result = await _userManager.CreateAsync(appUser, model.Password);

        if (result.Succeeded)
        {
            //await _signInManager.SignInAsync(appUser, isPersistent: false);

            

            return RedirectToAction("Login");
        }
        else
        {
            //ModelState.AddModelError("All", "Register zamani problem oldu");

            foreach (var item in result.Errors)
                ModelState.AddModelError("All", item.Description);

            return View(model);
        }
    }
}
