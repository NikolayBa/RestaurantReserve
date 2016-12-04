using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReserve.Data.Migrations
{
    public partial class updatedrestaurants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_ApplicationUserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_ApplicationUserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "restaurantId1",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_restaurantId1",
                table: "Restaurants",
                column: "restaurantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_UserId",
                table: "Restaurants",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_Restaurants_restaurantId1",
                table: "Restaurants",
                column: "restaurantId1",
                principalTable: "Restaurants",
                principalColumn: "restaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_AspNetUsers_UserId",
                table: "Restaurants");

            migrationBuilder.DropForeignKey(
                name: "FK_Restaurants_Restaurants_restaurantId1",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_UserId",
                table: "Restaurants");

            migrationBuilder.DropIndex(
                name: "IX_Restaurants_restaurantId1",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "restaurantId1",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ApplicationUserId",
                table: "Restaurants",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_ApplicationUserId",
                table: "Restaurants",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
