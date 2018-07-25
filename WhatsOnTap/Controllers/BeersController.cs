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
            BeerIndexViewModel viewModel = new BeerIndexViewModel(_db);
            return View(viewModel);
        }

        [HttpGet("/beers/sortby/name")]
        public ActionResult SortByName()
        {
            BeerIndexViewModel viewModel = new BeerIndexViewModel(_db);
            BeerIndexViewModel.FlipName();
            viewModel.SortByName();
            return View("Index", viewModel);
        }

        [HttpGet("/beers/sortby/style")]
        public ActionResult SortByStyle()
        {
            BeerIndexViewModel viewModel = new BeerIndexViewModel(_db);
            BeerIndexViewModel.FlipStyle();
            viewModel.SortByStyle();
            return View("Index", viewModel);
        }

        [HttpGet("/beers/sortby/abv")]
        public ActionResult SortByAbv()
        {
            BeerIndexViewModel viewModel = new BeerIndexViewModel(_db);
            BeerIndexViewModel.FlipAbv();
            viewModel.SortByAbv();
            return View("Index", viewModel);
        }

        [HttpGet("/beers/sortby/ibu")]
        public ActionResult SortByIbu()
        {
            BeerIndexViewModel viewModel = new BeerIndexViewModel(_db);
            BeerIndexViewModel.FlipIbu();
            viewModel.SortByIbu();
            return View("Index", viewModel);
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

            foreach (var barId in BarId)
            {
                Bar bar = _db.Bars.FirstOrDefault(item => item.BarId == barId);
                Taplist newTaplist = new Taplist(id, bar.BarId);
                _db.Taplists.Add(newTaplist);
            }

            _db.SaveChanges();
            return RedirectToAction("Details", new { id = viewModel.CurrentBeer.BeerId});
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
