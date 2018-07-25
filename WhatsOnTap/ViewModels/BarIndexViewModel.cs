using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;

namespace WhatsOnTap.ViewModels
{
    public class BarIndexViewModel
    {
        private readonly WhatsOnTapContext _db;
        public List<Bar> AllBars { get; set; }
        public List<string> AllNeighborhoods { get; set; } = new List<string>{};
        public List<Bar> Matches { get; set; }

        public BarIndexViewModel (WhatsOnTapContext context) {
            _db = context;
            AllBars = _db.Bars.ToList();
            Matches = _db.Bars.ToList();
            SetNeighborhoods();
        }

        public void SetNeighborhoods()
        {
            foreach (var bar in this.AllBars)
            {
                if (!AllNeighborhoods.Contains(bar.BarNeighborhood))
                {
                    AllNeighborhoods.Add(bar.BarNeighborhood);
                }
            }
        }

        public void FilterBy(string barNeighborhood, int barRating)
        {
            if (barNeighborhood == null)
            {
                var matches = _db.Bars.Where(entry => entry.BarRating >= barRating)
                                      .OrderByDescending(entry => entry.BarRating)
                                      .ToList();
                Matches = matches;
            }
            else
            {
                var matches = _db.Bars.Where(entry => entry.BarNeighborhood == barNeighborhood)
                                      .Where(entry => entry.BarRating >= barRating)
                                      .OrderByDescending(entry => entry.BarRating)
                                      .ToList();
                Matches = matches;
            } 
        }
    }
}