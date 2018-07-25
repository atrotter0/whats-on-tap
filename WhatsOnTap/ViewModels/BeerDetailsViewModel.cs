using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;

namespace WhatsOnTap.ViewModels
{
    public class BeerDetailsViewModel
    {
        private readonly WhatsOnTapContext _db;
        public List<Bar> BeerBars { get; set; }
        public List<Bar> AllBars {get; set; }
        public Beer CurrentBeer { get; set; }

        public BeerDetailsViewModel (WhatsOnTapContext context, int id) {
            _db = context;
            CurrentBeer = _db.Beers.FirstOrDefault(beers => beers.BeerId == id);
        }

        public void FindBeerBars(int id)
        {
            var Taplist = _db.Taplists.Where(entry => entry.BeerId == id).ToList();
            List<Bar> barList = new List<Bar>();
            foreach (var bar in Taplist)
            {
                int barId = bar.BarId;
                barList.Add(_db.Bars.FirstOrDefault(record => record.BarId == barId));
            }
            BeerBars = barList;
        }

        public void FindAllBars()
        {
            var Bars = _db.Bars.ToList();
            List<Bar> barList = new List<Bar>();
            foreach (var bar in Bars)
            {
                int barId = bar.BarId;
                barList.Add(_db.Bars.FirstOrDefault(record => record.BarId == barId));
            }
            AllBars = barList;
        }
    }
}
