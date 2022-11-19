using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AeroportShatohin.Migrations
{
    public partial class Mirror : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numfl = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TypeAir = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColPas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ColBuil = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Pass = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Build = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Percent = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Result = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADB", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADB");
        }
    }
}
