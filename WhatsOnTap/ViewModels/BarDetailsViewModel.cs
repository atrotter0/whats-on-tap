using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;

namespace WhatsOnTap.ViewModels
{
    public class BarDetailsViewModel
    {
        WhatsOnTapContext db = new WhatsOnTapContext();

        public List<Beer> BarBeers { get; set; }
        public Bar CurrentBar { get; set; }

        public BarDetailsViewModel (int id) {
            CurrentBar = db.Bars.FirstOrDefault(bars => bars.BarId == id);
        }

        public void FindBarBeers(int id)
        {
            var Taplist = db.Taplists.Where(entry => entry.BarId == id).ToList();
            List<Beer> beerList = new List<Beer>();
            foreach (var beer in Taplist)
            {
                int beerId = beer.BeerId;
                beerList.Add(db.Beers.FirstOrDefault(record => record.BeerId == beerId));
            }  
            BarBeers = beerList;          
        }
    }
}