using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WhatsOnTap.Models
{
    public class WhatsOnTap : DbContext
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public DbSet<Taplist> Taplists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=whatsontap;uid=root;pwd=root;");
        }
    }
}