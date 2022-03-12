using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class SeminarModelIzmjene : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Seminar",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NazivSeminara",
                table: "Seminar",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Seminar");

            migrationBuilder.DropColumn(
                name: "NazivSeminara",
                table: "Seminar");
        }
    }
}
