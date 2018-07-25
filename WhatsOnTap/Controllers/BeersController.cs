using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WhatsOnTap.Controllers
{
    public class BeersController : Controller
    {
        private readonly WhatsOnTapContext _db;

        public BeersController(WhatsOnTapContext context)
        {
            _db = context;
        }

        [HttpGet("/beers")]
        public ActionResult Index()
        {
            return View(_db.Beers.ToList());
        }

        [HttpGet("/beers/{id}")]
        public ActionResult Details(int id)
        {
            BeerDetailsViewModel viewModel = new BeerDetailsViewModel(_db, id);
            viewModel.FindBeerBars(id);
            return View(viewModel);
        }

        [HttpGet("/beers/{id}/edit")]
        public ActionResult Edit(int id)
        {
            BeerDetailsViewModel viewModel = new BeerDetailsViewModel(_db, id);
            viewModel.FindAllBars();
            return View(viewModel);
        }

        [HttpPost("/beers/{id}/edit")]
        public ActionResult Edit(List<int> BarId, Beer beer, int id)
        {
          _db.Entry(beer).State = EntityState.Modified;
          BeerDetailsViewModel viewModel = new BeerDetailsViewModel(_db, id);

          var beersToRemove = _db.Taplists.Where(entry => entry.BeerId == id).ToList();
          foreach (var beers in beersToRemove)
          {
            if (beers != null)
            {
              _db.Taplists.Remove(beers);
            }
          }

          foreach (int barId in BarId)
          {
              Taplist newTaplist = new Taplist(viewModel.CurrentBeer.BeerId, barId);
              _db.Taplists.Add(newTaplist);
          }
          _db.SaveChanges();

          return RedirectToAction("Index");
        }

        [HttpGet("/beers/new")]
        public ActionResult Create() => View(_db.Bars.ToList());

        [HttpPost("/beers/new")]
        public ActionResult Create(List<int> BarId, Beer beer)
        {
          _db.Add(beer);
            foreach (int barId in BarId)
            {
                Taplist newTaplist = new Taplist(beer.BeerId, barId);
                _db.Taplists.Add(newTaplist);
            }
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet("/beers/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Beer beer = _db.Beers.FirstOrDefault(beers => beers.BeerId == id);
            Taplist joinEntry = _db.Taplists.FirstOrDefault(entry => entry.BeerId == id);
            if (joinEntry != null)
            {
              _db.Taplists.Remove(joinEntry);
            }
            _db.Beers.Remove(beer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
