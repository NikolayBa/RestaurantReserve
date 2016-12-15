using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReserve.Data.Migrations
{
    public partial class picturl1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "url",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "pictureUrl",
                table: "Restaurants",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pictureUrl",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "url",
                table: "Restaurants",
                nullable: true);
        }
    }
}
