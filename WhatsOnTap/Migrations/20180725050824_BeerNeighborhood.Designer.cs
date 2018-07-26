using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WhatsOnTap.Models;

namespace WhatsOnTap.Migrations
{
    [DbContext(typeof(WhatsOnTapContext))]
    [Migration("20180725050824_BeerNeighborhood")]
    partial class BeerNeighborhood
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WhatsOnTap.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(127);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(127);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(127);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(127);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Bar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarCity");

                    b.Property<double>("BarLatitude");

                    b.Property<double>("BarLongitude");

                    b.Property<string>("BarName");

                    b.Property<string>("BarNeighborhood");

                    b.Property<string>("BarPhone");

                    b.Property<int>("BarRating");

                    b.Property<string>("BarState");

                    b.Property<string>("BarStreet");

                    b.Property<string>("BarWebsite");

                    b.Property<string>("BarZip");

                    b.HasKey("BarId");

                    b.ToTable("Bars");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Beer", b =>
                {
                    b.Property<int>("BeerId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("BeerAbv");

                    b.Property<string>("BeerBreweryName");

                    b.Property<int>("BeerIbu");

                    b.Property<string>("BeerName");

                    b.Property<string>("BeerStyle");

                    b.HasKey("BeerId");

                    b.ToTable("Beers");
                });

            modelBuilder.Entity("WhatsOnTap.Models.Taplist", b =>
                {
                    b.Property<int>("TaplistId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BarId");

                    b.Property<int>("BeerId");

                    b.HasKey("TaplistId");

                    b.HasIndex("BarId");

                    b.HasIndex("BeerId");

                    b.ToTable("Taplists");
                });

            modelBuilder.Entity("WhatsOnTap.Models.UserBeer", b =>
                {
                    b.Property<int>("UserBeerId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BeerId");

                    b.Property<bool>("Favorite");

                    b.Property<string>("Notes");

                    b.Property<string>("UserId");

                    b.HasKey("UserBeerId");

                    b.HasIndex("UserId");

                    b.ToTable("UsersBeers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WhatsOnTap.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WhatsOnTap.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhatsOnTap.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhatsOnTap.Models.Taplist", b =>
                {
                    b.HasOne("WhatsOnTap.Models.Bar", "Bars")
                        .WithMany("Taplists")
                        .HasForeignKey("BarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WhatsOnTap.Models.Beer", "Beers")
                        .WithMany("Taplists")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WhatsOnTap.Models.UserBeer", b =>
                {
                    b.HasOne("WhatsOnTap.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
