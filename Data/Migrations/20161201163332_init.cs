using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantReserve.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    restaurantId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    address = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.restaurantId);
                });

            migrationBuilder.CreateTable(
                name: "Table",
                columns: table => new
                {
                    tableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isReserved = table.Column<bool>(nullable: false),
                    leftPos = table.Column<double>(nullable: false),
                    objHeight = table.Column<double>(nullable: false),
                    objWidth = table.Column<double>(nullable: false),
                    restaurantId = table.Column<int>(nullable: true),
                    rotationAng = table.Column<int>(nullable: false),
                    topPos = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Table", x => x.tableId);
                    table.ForeignKey(
                        name: "FK_Table_Restaurants_restaurantId",
                        column: x => x.restaurantId,
                        principalTable: "Restaurants",
                        principalColumn: "restaurantId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "restaurantId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_restaurantId",
                table: "AspNetUsers",
                column: "restaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Table_restaurantId",
                table: "Table",
                column: "restaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Restaurants_restaurantId",
                table: "AspNetUsers",
                column: "restaurantId",
                principalTable: "Restaurants",
                principalColumn: "restaurantId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Table");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
