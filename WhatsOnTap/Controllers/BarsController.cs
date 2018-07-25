using System.Collections.Generic;
using System.Linq;
using System;
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

        [HttpGet("/bars/new")]
        public ActionResult Create() => View(_db.Beers.ToList());

        [HttpPost("/bars/new")]
        public ActionResult Create(List<int> BeerId, string barName, string barRating, string barWebsite, string barStreet, string barCity, string barState, string barZip, string barPhone, string barLatitude, string barLongitude)
        {
            Bar newBar = new Bar();
            newBar.BarName = barName;
            newBar.BarRating = int.Parse(barRating);
            newBar.BarWebsite = barWebsite;
            newBar.BarStreet = barStreet;
            newBar.BarCity = barCity;
            newBar.BarState = barState;
            newBar.BarZip = barZip;
            newBar.BarPhone = barPhone;
            newBar.BarLatitude = Convert.ToDouble(barLatitude);
            newBar.BarLongitude = Convert.ToDouble(barLongitude);

            _db.Add(newBar);
            foreach (int beerId in BeerId)
            {
                Taplist newTaplist = new Taplist(beerId, newBar.BarId);
                _db.Taplists.Add(newTaplist);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
