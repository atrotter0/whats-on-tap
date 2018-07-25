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

        [HttpGet("/bars/{id}/edit")]
        public ActionResult Edit(int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.FindAllBeers();
            return View(viewModel);
        }

        [HttpPost("/bars/{id}/edit")]
        public ActionResult Edit(List<int> BeerId, string barName, string barRating, string barWebsite, string barStreet, string barCity, string barState, string barZip, string barPhone, string barLatitude, string barLongitude, int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.CurrentBar.BarName = barName;
            viewModel.CurrentBar.BarRating = int.Parse(barRating);
            viewModel.CurrentBar.BarWebsite = barWebsite;
            viewModel.CurrentBar.BarStreet = barStreet;
            viewModel.CurrentBar.BarCity = barCity;
            viewModel.CurrentBar.BarState = barState;
            viewModel.CurrentBar.BarZip = barZip;
            viewModel.CurrentBar.BarPhone = barPhone;
            viewModel.CurrentBar.BarLatitude = Convert.ToDouble(barLatitude);
            viewModel.CurrentBar.BarLongitude = Convert.ToDouble(barLongitude);
            viewModel.CurrentBar.BarNeighborhood = barNeighborhood;
            var barsToRemove = _db.Taplists.Where(entry => entry.BarId == id).ToList();
            foreach (var bars in barsToRemove)
            {
              if (bars != null)
              {
                _db.Taplists.Remove(bars);
              }
            }

            foreach (int beerId in BeerId)
            {
                Taplist newTaplist = new Taplist(beerId, viewModel.CurrentBar.BarId);
                _db.Taplists.Add(newTaplist);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
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
            newBar.BarNeighborhood = barNeighborhood;
            _db.Add(newBar);
            foreach (int beerId in BeerId)
            {
                Taplist newTaplist = new Taplist(beerId, newBar.BarId);
                _db.Taplists.Add(newTaplist);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("/bars/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Bar bar = _db.Bars.FirstOrDefault(bars => bars.BarId == id);
            Taplist joinEntry = _db.Taplists.FirstOrDefault(entry => entry.BarId == id);
            if (joinEntry != null)
            {
              _db.Taplists.Remove(joinEntry);
            }
            _db.Bars.Remove(bar);
            _db.SaveChanges();
            return RedirectToAction("Index");
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
