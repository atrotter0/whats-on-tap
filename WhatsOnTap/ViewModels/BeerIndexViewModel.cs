using System;
using System.Collections.Generic;
using System.Linq;
using WhatsOnTap.Models;

namespace WhatsOnTap.ViewModels
{
    public class BeerIndexViewModel
    {
        private readonly WhatsOnTapContext _db;
        public List<Beer> AllBeers { get; set; }
        public List<Beer> Matches { get; set; }
        public static bool ReverseName { get; set; } = false;
        public static bool ReverseStyle { get; set; } = false;
        public static bool ReverseAbv { get; set; } = false;
        public static bool ReverseIbu { get; set; } = false;

        public BeerIndexViewModel(WhatsOnTapContext context)
        {
            _db = context;
            AllBeers = _db.Beers.ToList();
            Matches = _db.Beers.ToList();
        }

        public static void FlipName()
        {
            if (ReverseName == true)
            {
                ReverseName = false;
            }
            else
            {
                ReverseName = true;
            }
        }

        public static void FlipStyle()
        {
            if (ReverseStyle == true)
            {
                ReverseStyle = false;
            }
            else
            {
                ReverseStyle = true;
            }
        }

        public static void FlipAbv()
        {
            if (ReverseAbv == true)
            {
                ReverseAbv = false;
            }
            else
            {
                ReverseAbv = true;
            }
        }
        
        public static void FlipIbu()
        {
            if (ReverseIbu == true)
            {
                ReverseIbu = false;
            }
            else
            {
                ReverseIbu = true;
            }
        }                        

        public void SortByName()
        {
            if (ReverseName == true)
            {
                var matches = _db.Beers.OrderBy(entry => entry.BeerName).ToList();
                Matches = matches;
            }
            else
            {
                var matches = _db.Beers.OrderByDescending(entry => entry.BeerName).ToList();
                Matches = matches;
            }
        }

        public void SortByStyle()
        {
            if (ReverseStyle == true)
            {
                var matches = _db.Beers.OrderBy(entry => entry.BeerStyle).ToList();
                Matches = matches;
            }
            else
            {
                var matches = _db.Beers.OrderByDescending(entry => entry.BeerStyle).ToList();
                Matches = matches;
            }
        }

        public void SortByAbv()
        {
            if (ReverseAbv == true)
            {
                var matches = _db.Beers.OrderBy(entry => entry.BeerAbv).ToList();
                Matches = matches;
            }
            else
            {
                var matches = _db.Beers.OrderByDescending(entry => entry.BeerAbv).ToList();
                Matches = matches;
            }
        }

        public void SortByIbu()
        {
            if (ReverseIbu == true)
            {
                var matches = _db.Beers.OrderBy(entry => entry.BeerIbu).ToList();
                Matches = matches;
            }
            else
            {
                var matches = _db.Beers.OrderByDescending(entry => entry.BeerIbu).ToList();
                Matches = matches;
            }
        }
    }
}