<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
=======
using System;
>>>>>>> develop
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            viewModel.FindBarsForBeer(id);
            return View(viewModel);
        }
        
        [HttpGet("/beers/new")]
        public ActionResult Create() => View(_db.Bars.ToList());

        [HttpPost("/beers/new")]
        public ActionResult Create(int barId, string beerName, string brewery, string style, string abv, string ibu)
        {
            Beer newBeer = new Beer();
            newBeer.BeerName = beerName;
            newBeer.BeerBreweryName = brewery;
            newBeer.BeerStyle = style;
            newBeer.BeerAbv = Convert.ToDouble(abv);
            newBeer.BeerIbu = int.Parse(ibu);
            
            _db.Add(newBeer);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
