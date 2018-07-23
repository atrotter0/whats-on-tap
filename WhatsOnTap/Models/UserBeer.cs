using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatsOnTap;

namespace WhatsOnTap.Models
{
    [Table("UsersBeers")]
    public class UserBeer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserBeerId { get; set; }
        public int UserId { get; set; }
        public int BeerId { get; set; }
        public bool Favorite { get; set; }
        public string Notes { get; set; }
    }
}