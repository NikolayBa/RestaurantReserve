using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantReserve.Data.Migrations
{
    public partial class physicaltable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhysicalTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isReserved = table.Column<bool>(nullable: false),
                    leftPos = table.Column<double>(nullable: false),
                    objHeight = table.Column<double>(nullable: false),
                    objWidth = table.Column<double>(nullable: false),
                    restaurantId = table.Column<int>(nullable: false),
                    rotationAng = table.Column<int>(nullable: false),
                    topPos = table.Column<double>(nullable: false),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalTables", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalTables");
        }
    }
}
