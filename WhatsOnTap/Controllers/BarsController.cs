using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;

namespace WhatsOnTap.Controllers
{
    public class BarsController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
