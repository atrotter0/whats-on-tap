using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsOnTap.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    BarId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BarCity = table.Column<string>(nullable: true),
                    BarLatitude = table.Column<double>(nullable: false),
                    BarLongitude = table.Column<double>(nullable: false),
                    BarName = table.Column<string>(nullable: true),
                    BarPhone = table.Column<string>(nullable: true),
                    BarRating = table.Column<int>(nullable: false),
                    BarState = table.Column<string>(nullable: true),
                    BarStreet = table.Column<string>(nullable: true),
                    BarWebsite = table.Column<string>(nullable: true),
                    BarZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.BarId);
                });

            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BeerAbv = table.Column<double>(nullable: false),
                    BeerBreweryName = table.Column<string>(nullable: true),
                    BeerIbu = table.Column<int>(nullable: false),
                    BeerName = table.Column<string>(nullable: true),
                    BeerStyle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "UsersBeers",
                columns: table => new
                {
                    UserBeerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BeerId = table.Column<int>(nullable: false),
                    Favorite = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersBeers", x => x.UserBeerId);
                });

            migrationBuilder.CreateTable(
                name: "Taplists",
                columns: table => new
                {
                    TaplistId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGeneratedOnAdd", true),
                    BarId = table.Column<int>(nullable: false),
                    BeerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taplists", x => x.TaplistId);
                    table.ForeignKey(
                        name: "FK_Taplists_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "BarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Taplists_Beers_BeerId",
                        column: x => x.BeerId,
                        principalTable: "Beers",
                        principalColumn: "BeerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Taplists_BarId",
                table: "Taplists",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_Taplists_BeerId",
                table: "Taplists",
                column: "BeerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Taplists");

            migrationBuilder.DropTable(
                name: "UsersBeers");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Beers");
        }
    }
}
