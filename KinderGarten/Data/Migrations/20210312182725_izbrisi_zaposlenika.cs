using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class izbrisi_zaposlenika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izlet_Zaposlenik_ZaposlenikID",
                table: "Izlet");

            migrationBuilder.DropIndex(
                name: "IX_Izlet_ZaposlenikID",
                table: "Izlet");

            migrationBuilder.DropColumn(
                name: "ZaposlenikID",
                table: "Izlet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ZaposlenikID",
                table: "Izlet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Izlet_ZaposlenikID",
                table: "Izlet",
                column: "ZaposlenikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Izlet_Zaposlenik_ZaposlenikID",
                table: "Izlet",
                column: "ZaposlenikID",
                principalTable: "Zaposlenik",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
