using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WhatsOnTap.Models
{
    public class WhatsOnTapContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Taplist> Taplists { get; set; }
        public virtual DbSet<UserBeer> UsersBeers { get; set; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySql(@"Server=localhost;Port=8889;database=whatsontap;uid=root;pwd=root;");
        // }

        public WhatsOnTapContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });
            builder.Entity<IdentityRole>(entity => {
                entity.Property(m => m.Name).HasMaxLength(127); entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });
        }
    }
}