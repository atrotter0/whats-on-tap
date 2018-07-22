using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatsOnTap;

namespace WhatsOnTap.Models
{
    [Table("Bars")]
    public class Bar
    {
        [Key]
        public int BarId { get; set; }
        public string BarName { get; set; }
        public int BarRating { get; set; }
        public string BarWebsite { get; set; }
        public string BarAddress { get; set; }
        public string BarPhone { get; set; }
        public double BarLatitude { get; set; }
        public double BarLongitude { get; set; }
    }
}
