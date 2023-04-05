using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using lab7_Identity_.Database;
using System.Security.Claims;
using lab7_Identity_.Dtos;

namespace lab7_Identity_.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<Student> _userManager;
    private readonly SignInManager<Student> _signInManager;

    public UsersController(UserManager<Student> userManager,
        SignInManager<Student> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }


    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto credentials)
    {
        var user = await _userManager.FindByNameAsync(credentials.UserName);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, errorMessage: "Couldn't find");
            return View();
        }

        var isAuthenticated = await _userManager.CheckPasswordAsync(user,
            credentials.Password);
        if (!isAuthenticated)
        {
            ModelState.AddModelError(string.Empty, errorMessage: "not authenticated");
            return View();
        }

        var claims = await _userManager.GetClaimsAsync(user);
        await _signInManager.SignInWithClaimsAsync(user, true, claims);

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        var user = new Student
        {
            UserName = registerDto.UserName,
            Email = registerDto.Email,
            DateOfBirth = registerDto.DOB
        };
        var creationResult = await _userManager.CreateAsync(user, registerDto.Password);
        if (!creationResult.Succeeded)
        {
            ModelState.AddModelError(string.Empty, creationResult.Errors.First().Description);
            return View();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Role, "User"),
        };

        await _userManager.AddClaimsAsync(user, claims);

        return RedirectToAction("Login");
    }

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
