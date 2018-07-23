using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;

namespace WhatsOnTap.Controllers
{
    public class BarsController : Controller
    {
        [HttpGet("/bars")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
