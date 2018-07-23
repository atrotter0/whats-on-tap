using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WhatsOnTap.Models;
using Microsoft.AspNetCore.Identity;

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

        [HttpGet("/user")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("/user/{id}/favorites")]
        public IActionResult AddFavorite(int id, int beerId)
        {
            //add logic here
            return View();
        }

    }
}