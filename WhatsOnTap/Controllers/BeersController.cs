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
            viewModel.FindBeerBars(id);
            return View(viewModel);
        }

        [HttpPost("/beers/{id}/edit")]
        public ActionResult Edit(List<int> BarId, string beerName, string brewery, string style, string abv, int ibu, int id)
        {
          BeerDetailsViewModel viewModel = new BeerDetailsViewModel(_db, id);
          viewModel.CurrentBeer.BeerName = beerName;
          viewModel.CurrentBeer.BeerBreweryName = brewery;
          viewModel.CurrentBeer.BeerStyle = style;
          viewModel.CurrentBeer.BeerAbv = Convert.ToDouble(abv);
          viewModel.CurrentBeer.BeerIbu = ibu;

          var beersToRemove = _db.Taplists.Where(entry => entry.BeerId == id).ToList();
          foreach (var beer in beersToRemove)
          {
            if (beer != null)
            {
              _db.Taplists.Remove(beer);
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
        public ActionResult Create(List<int> BarId, string beerName, string brewery, string style, string abv, string ibu)
        {
            Beer newBeer = new Beer();
            newBeer.BeerName = beerName;
            newBeer.BeerBreweryName = brewery;
            newBeer.BeerStyle = style;
            newBeer.BeerAbv = Convert.ToDouble(abv);
            newBeer.BeerIbu = int.Parse(ibu);

            _db.Add(newBeer);
            foreach (int barId in BarId)
            {
                Taplist newTaplist = new Taplist(newBeer.BeerId, barId);
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
