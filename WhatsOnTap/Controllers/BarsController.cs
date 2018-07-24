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
        private readonly WhatsOnTapContext _db;

        public BarsController(WhatsOnTapContext context)
        {
            _db = context;
        }

        [HttpGet("/bars")]
        public ActionResult Index() => View(_db.Bars.ToList());

        [HttpGet("bars/{id}")]
        public ActionResult Details(int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.FindBarBeers(id);
            return View(viewModel);
        }
    }
}
