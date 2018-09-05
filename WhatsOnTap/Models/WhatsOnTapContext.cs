using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace WhatsOnTap.Models
{
    public class WhatsOnTapContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Beer> Beers { get; set; }
        public virtual DbSet<Taplist> Taplists { get; set; }
        public virtual DbSet<UserBeer> UsersBeers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"Server=" + System.Environment.GetEnvironmentVariable("DATABASE_SERVER") +
                                        ";Port=" + System.Environment.GetEnvironmentVariable("DATABASE_PORT") +
                                        ";uid=" + System.Environment.GetEnvironmentVariable("DATABASE_USER") +
                                        ";pwd=" + System.Environment.GetEnvironmentVariable("DATABASE_PASSWORD")
                                    );
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