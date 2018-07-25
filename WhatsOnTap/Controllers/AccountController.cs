using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WhatsOnTap.Models;
using System.Threading.Tasks;
using WhatsOnTap.ViewModels;

namespace WhatsOnTap.Controllers
{
    public class AccountController : Controller
    {
        private readonly WhatsOnTapContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, WhatsOnTapContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }

        [HttpGet("/user")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/signup")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("/signup")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                if (model.UserType == "owner")
                {
                    await _userManager.AddToRoleAsync(user, "owner");
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "user");
                }

                Microsoft.AspNetCore.Identity.SignInResult login = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> LogOff()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });       
        }

    }
}