using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;

namespace WhatsOnTap.ViewModels
{
    public class BarDetailsViewModel
    {
        private readonly WhatsOnTapContext _db;
        public List<Beer> BarBeers { get; set; }
        public Bar CurrentBar { get; set; }

        public BarDetailsViewModel (WhatsOnTapContext context, int id)
        {
            _db = context;
            CurrentBar = _db.Bars.FirstOrDefault(bars => bars.BarId == id);
        }

        public void FindBarBeers(int id)
        {
            var Taplist = _db.Taplists.Where(entry => entry.BarId == id).ToList();
            List<Beer> beerList = new List<Beer>();
            foreach (var beer in Taplist)
            {
                int beerId = beer.BeerId;
                beerList.Add(_db.Beers.FirstOrDefault(record => record.BeerId == beerId));
            }  
            BarBeers = beerList;          
        }
    }
}