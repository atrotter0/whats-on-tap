using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WhatsOnTap.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace WhatsOnTap.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly WhatsOnTapContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController (UserManager<ApplicationUser> userManager, WhatsOnTapContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [HttpGet("/user/{id}")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/user/{id}/beers")]
        public IActionResult Beers()
        {
            return View();
        }

        [HttpPost("/user/{id}/beers")]
        public async Task<IActionResult> AddBeer(int id, int beerId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            UserBeer userBeer = new UserBeer();
            userBeer.User = currentUser;
            return RedirectToAction("Beers");
        }

    }
}