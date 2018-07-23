using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhatsOnTap.Controllers
{
    public class BarsController : Controller
    {
        WhatsOnTapContext db = new WhatsOnTapContext();

        [HttpGet("/bars")]
        public ActionResult Index() => View(db.Bars.ToList());

        [HttpGet("bars/{id}")]
        public ActionResult Details(int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(id);
            viewModel.FindBarBeers(id);
            return View(viewModel);
        }
    }
}
