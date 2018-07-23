using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WhatsOnTap.Models;

namespace WhatsOnTap.Migrations
{
    [DbContext(typeof(WhatsOnTapContext))]
    partial class WhatsOnTapContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1");

            modelBuilder.Entity("WhatsOnTap.Models.Bar", b =>
                {
                    b.Property<int>("BarId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BarCity");

                    b.Property<double>("BarLatitude");

                    b.Property<double>("BarLongitude");

                    b.Property<string>("BarName");

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

                    b.Property<int>("UserId");

                    b.HasKey("UserBeerId");

                    b.ToTable("UsersBeers");
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
        }
    }
}
