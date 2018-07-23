using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatsOnTap;

namespace WhatsOnTap.Models
{
    [Table("Beers")]
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BeerId { get; set; }
        public string BeerName { get; set; }
        public string BeerBreweryName { get; set; }
        public string BeerStyle { get; set; }
        public double BeerAbv { get; set; }
        public int BeerIbu { get; set; }

        public virtual ICollection<Taplist> Taplists { get; set; }
    }
}