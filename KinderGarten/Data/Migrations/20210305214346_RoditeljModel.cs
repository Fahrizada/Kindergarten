using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class RoditeljModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Dijete");

            migrationBuilder.DropColumn(
                name: "BrojTelefona",
                table: "Dijete");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dijete");

            migrationBuilder.AddColumn<int>(
                name: "RoditeljID",
                table: "Dijete",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Roditelj",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JMBG = table.Column<string>(nullable: true),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    Adresa = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PutanjaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roditelj", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dijete_RoditeljID",
                table: "Dijete",
                column: "RoditeljID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dijete_Roditelj_RoditeljID",
                table: "Dijete",
                column: "RoditeljID",
                principalTable: "Roditelj",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dijete_Roditelj_RoditeljID",
                table: "Dijete");

            migrationBuilder.DropTable(
                name: "Roditelj");

            migrationBuilder.DropIndex(
                name: "IX_Dijete_RoditeljID",
                table: "Dijete");

            migrationBuilder.DropColumn(
                name: "RoditeljID",
                table: "Dijete");

            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Dijete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BrojTelefona",
                table: "Dijete",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dijete",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
