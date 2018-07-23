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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BarId { get; set; }
        public string BarName { get; set; }
        public int BarRating { get; set; }
        public string BarWebsite { get; set; }
        public string BarStreet { get; set; }
        public string BarCity { get; set; }
        public string BarState { get; set; }
        public string BarZip { get; set; }
        public string BarPhone { get; set; }
        public double BarLatitude { get; set; }
        public double BarLongitude { get; set; }

        public virtual ICollection<Taplist> Taplists { get; set; }
    }
}
