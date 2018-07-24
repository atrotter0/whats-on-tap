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
    }
}
