using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WhatsOnTap.Migrations
{
    public partial class MakeUserIdString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UsersBeers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_UsersBeers_UserId",
                table: "UsersBeers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersBeers_AspNetUsers_UserId",
                table: "UsersBeers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersBeers_AspNetUsers_UserId",
                table: "UsersBeers");

            migrationBuilder.DropIndex(
                name: "IX_UsersBeers_UserId",
                table: "UsersBeers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "UsersBeers",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
