using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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

        [Authorize(Roles="owner, admin")]
        [HttpGet("/bars/{id}/edit")]
        public ActionResult Edit(int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.FindAllBeers();
            viewModel.FindBarBeers(id);
            return View(viewModel);
        }

        [HttpPost("/bars/{id}/edit")]
        public ActionResult Edit(Bar bar, List<int> BeerId, string BarName, string BarRating, string BarWebsite, string BarStreet, string BarCity, string BarState, string BarZip, string BarPhone, string BarLatitude, string BarLongitude, string BarNeighborhood, int id)
        {
            BarDetailsViewModel viewModel = new BarDetailsViewModel(_db, id);
            viewModel.CurrentBar.BarName = BarName;
            viewModel.CurrentBar.BarRating = int.Parse(BarRating);
            viewModel.CurrentBar.BarWebsite = BarWebsite;
            viewModel.CurrentBar.BarStreet = BarStreet;
            viewModel.CurrentBar.BarCity = BarCity;
            viewModel.CurrentBar.BarState = BarState;
            viewModel.CurrentBar.BarZip = BarZip;
            viewModel.CurrentBar.BarPhone = BarPhone;
            viewModel.CurrentBar.BarLatitude = Convert.ToDouble(BarLatitude);
            viewModel.CurrentBar.BarLongitude = Convert.ToDouble(BarLongitude);
            viewModel.CurrentBar.BarNeighborhood = BarNeighborhood;
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

        [Authorize(Roles="admin")]
        [HttpGet("/bars/new")]
        public ActionResult Create() => View(_db.Beers.ToList());

        [HttpPost("/bars/new")]
        public ActionResult Create(Bar bar, List<int> BeerId)
        {
            _db.Bars.Add(bar);
            
            foreach (int beerId in BeerId)
            {
                Taplist newTaplist = new Taplist(beerId, bar.BarId);
                _db.Taplists.Add(newTaplist);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize(Roles="admin")]
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
