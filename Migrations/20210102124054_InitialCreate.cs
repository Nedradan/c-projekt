using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MuzykaAlbumy.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albumy",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazwaAlbumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wykonawca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gatunekMuzyczny = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    wersjaAlbumu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataZakupu = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albumy", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albumy");
        }
    }
}
