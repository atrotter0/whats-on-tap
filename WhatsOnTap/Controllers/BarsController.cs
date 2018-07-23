using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
