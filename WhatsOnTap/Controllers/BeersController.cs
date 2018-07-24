using System;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using System.Linq;
using System.Collections.Generic;
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
            Beer beer = _db.Beers.FirstOrDefault(beers => beers.BeerId == id);
            return View(beer);
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
