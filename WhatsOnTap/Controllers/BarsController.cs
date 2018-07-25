using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
        public ActionResult Index() {
            BarIndexViewModel viewModel = new BarIndexViewModel(_db);
            return View(viewModel);
        }

        [HttpGet("bars/{id}")]
        public ActionResult Details(int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.FindBarBeers(id);
            return View(viewModel);
        }

        [HttpGet("bars/filter")]
        public ActionResult FilterBy(string barNeighborhood, int barRating)
        {
            BarIndexViewModel viewModel = new BarIndexViewModel(_db);
            viewModel.FilterBy(barNeighborhood, barRating);
            return View ("Index", viewModel);
        }
    }
}