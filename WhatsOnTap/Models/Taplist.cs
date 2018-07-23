using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatsOnTap;

namespace WhatsOnTap.Models
{
    [Table("Taplists")]
    public class Taplist
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaplistId { get; set; }
        public int BarId { get; set; }
        public int BeerId { get; set; }
        public virtual Beer Beers { get; set; }
        public virtual Bar Bars { get; set; }

        public Taplist() {}

        public Taplist(int beerId, int barId)
        {
            BeerId = beerId;
            BarId = barId;
        }
    }
}