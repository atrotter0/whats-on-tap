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
        public int TaplistId { get; set; }
        public int BarId { get; set; }
        public int BeerId { get; set; }
    }
}