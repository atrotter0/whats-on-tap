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
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel model)
        {
            var user = new ApplicationUser { UserName = model.Email };
            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}