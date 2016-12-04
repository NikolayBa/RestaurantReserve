using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReserve.Data.Migrations
{
    public partial class fixed_a_column : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Restaurants_restaurantId1",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_restaurantId1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "restaurantId1",
                table: "Restaurants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "restaurantId1",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_restaurantId1",
                table: "Restaurants",
                column: "restaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Restaurants_restaurantId1",
                table: "Restaurants",
                column: "restaurantId1",
                principalTable: "Restaurants",
                principalColumn: "restaurantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
