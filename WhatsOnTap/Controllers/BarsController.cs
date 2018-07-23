using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;

namespace WhatsOnTap.Controllers
{
    public class BarsController : Controller
    {

        WhatsOnTapContext db = new WhatsOnTapContext();

        [HttpGet("/bars")]
        public ActionResult Index() => View(db.Bars.ToList());
    }
}
