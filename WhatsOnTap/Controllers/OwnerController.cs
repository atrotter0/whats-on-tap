using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WhatsOnTap.Models;
using WhatsOnTap.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WhatsOnTap.Controllers
{
    public class OwnerController : Controller
    {
        private readonly WhatsOnTapContext _db;

        public OwnerController(WhatsOnTapContext context)
        {
            _db = context;
        }

        [HttpGet("/owner")]
        public ActionResult Index() 
        {
            return View();
        } 
    }
}

