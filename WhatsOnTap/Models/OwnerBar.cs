using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatsOnTap;

namespace WhatsOnTap.Models
{
    [Table("OwnerBar")]
    public class OwnerBar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OwnerBarId { get; set; }
        public int UserId { get; set; }
        public int BarId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public OwnerBar() {}
    }
}