using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantReserve.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Restaurants_restaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_restaurantId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "restaurantId",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "RestaurantsUser",
                columns: table => new
                {
                    RestaurantId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantsUser", x => new { x.RestaurantId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RestaurantsUser_Restaurants_RestaurantId",
                        column: x => x.RestaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurantId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantsUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Restaurants",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ApplicationUserId",
                table: "Restaurants",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsUser_RestaurantId",
                table: "RestaurantsUser",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantsUser_UserId",
                table: "RestaurantsUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Restaurants_AspNetUsers_ApplicationUserId",
                table: "Restaurants",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "RestaurantsUser");

            migrationBuilder.AddColumn<int>(
                name: "restaurantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_restaurantId",
                table: "AspNetUsers",
                column: "restaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restaurants_restaurantId",
                table: "AspNetUsers",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "restaurantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
