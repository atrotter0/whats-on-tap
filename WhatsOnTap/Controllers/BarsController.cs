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
        public ActionResult Index() => View(_db.Bars.ToList());

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
            if (barNeighborhood == null && barRating == 0)
            {
                var matches = _db.Bars.ToList();
                return View ("Index", matches);
            }
            else if (barRating == 0)
            {
                var matches = _db.Bars.Where(entry => entry.BarNeighborhood == barNeighborhood);
                return View ("Index", matches);
            }
            else if (barNeighborhood == null)
            {
                var matches = _db.Bars.Where(entry => entry.BarRating >= barRating)
                                      .OrderByDescending(entry => entry.BarRating)
                                      .ToList();
                return View ("Index", matches);
            }
            else
            {
                var matches = _db.Bars.Where(entry => entry.BarNeighborhood == barNeighborhood)
                                      .Where(entry => entry.BarRating >= barRating)
                                      .OrderByDescending(entry => entry.BarRating)
                                      .ToList();
                return View ("Index", matches);
            } 
        }
    }
}