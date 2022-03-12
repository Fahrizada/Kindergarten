using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class IzmjenaEvidencije : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidencija_OvlastenaOsoba_OvlastenaOsobaID",
                table: "Evidencija");

            migrationBuilder.DropIndex(
                name: "IX_Evidencija_OvlastenaOsobaID",
                table: "Evidencija");

            migrationBuilder.DropColumn(
                name: "OvlastenaOsobaID",
                table: "Evidencija");

            migrationBuilder.AddColumn<int>(
                name: "RoditeljID",
                table: "Evidencija",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_RoditeljID",
                table: "Evidencija",
                column: "RoditeljID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencija_Roditelj_RoditeljID",
                table: "Evidencija",
                column: "RoditeljID",
                principalTable: "Roditelj",
                principalColumn: "ID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Evidencija_Roditelj_RoditeljID",
                table: "Evidencija");

            migrationBuilder.DropIndex(
                name: "IX_Evidencija_RoditeljID",
                table: "Evidencija");

            migrationBuilder.DropColumn(
                name: "RoditeljID",
                table: "Evidencija");

            migrationBuilder.AddColumn<int>(
                name: "OvlastenaOsobaID",
                table: "Evidencija",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_OvlastenaOsobaID",
                table: "Evidencija",
                column: "OvlastenaOsobaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Evidencija_OvlastenaOsoba_OvlastenaOsobaID",
                table: "Evidencija",
                column: "OvlastenaOsobaID",
                principalTable: "OvlastenaOsoba",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
