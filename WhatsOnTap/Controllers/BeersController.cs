using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;

namespace WhatsOnTap.Controllers
{
    public class BeersController : Controller
    {
        [HttpGet("/beers")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
