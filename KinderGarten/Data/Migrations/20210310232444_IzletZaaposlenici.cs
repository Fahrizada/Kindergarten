using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class IzletZaaposlenici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IzletZaposlenici",
                columns: table => new
                {
                    IzletID = table.Column<int>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzletZaposlenici", x => new { x.IzletID, x.ZaposlenikID });
                    table.ForeignKey(
                        name: "FK_IzletZaposlenici_Izlet_IzletID",
                        column: x => x.IzletID,
                        principalTable: "Izlet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IzletZaposlenici_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IzletZaposlenici_ZaposlenikID",
                table: "IzletZaposlenici",
                column: "ZaposlenikID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IzletZaposlenici");
        }
    }
}
