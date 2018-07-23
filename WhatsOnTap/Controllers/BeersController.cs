using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;

namespace WhatsOnTap.Controllers
{
    public class BeersController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
