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

        public WhatsOnTapContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"User ID=" + System.Environment.GetEnvironmentVariable("DATABASE_USER") +
                                        ";Password=" + System.Environment.GetEnvironmentVariable("DATABASE_PASSWORD") +
                                        ";Host=" + System.Environment.GetEnvironmentVariable("DATABASE_HOST") +
                                        ";Port=" + System.Environment.GetEnvironmentVariable("DATABASE_PORT") +
                                        ";Database=" + System.Environment.GetEnvironmentVariable("DATABASE_NAME") +
                                        ";Pooling=true;Use SSL Stream=True;SSL Mode=Require;TrustServerCertificate=True;"
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