using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantReserve.Data.Migrations
{
    public partial class physicalt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Table");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Table_restaurantId",
                table: "Table",
                column: "restaurantId");
        }
    }
}
