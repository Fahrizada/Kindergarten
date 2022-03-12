using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class IzmjenaUplate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_OvlastenaOsoba_OvlastenaOsobaID",
                table: "Uplata");

            migrationBuilder.DropIndex(
                name: "IX_Uplata_OvlastenaOsobaID",
                table: "Uplata");

            migrationBuilder.DropColumn(
                name: "OvlastenaOsobaID",
                table: "Uplata");

            migrationBuilder.AddColumn<int>(
                name: "RoditeljID",
                table: "Uplata",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_RoditeljID",
                table: "Uplata",
                column: "RoditeljID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_Roditelj_RoditeljID",
                table: "Uplata",
                column: "RoditeljID",
                principalTable: "Roditelj",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Uplata_Roditelj_RoditeljID",
                table: "Uplata");

            migrationBuilder.DropIndex(
                name: "IX_Uplata_RoditeljID",
                table: "Uplata");

            migrationBuilder.DropColumn(
                name: "RoditeljID",
                table: "Uplata");

            migrationBuilder.AddColumn<int>(
                name: "OvlastenaOsobaID",
                table: "Uplata",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_OvlastenaOsobaID",
                table: "Uplata",
                column: "OvlastenaOsobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Uplata_OvlastenaOsoba_OvlastenaOsobaID",
                table: "Uplata",
                column: "OvlastenaOsobaID",
                principalTable: "OvlastenaOsoba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
