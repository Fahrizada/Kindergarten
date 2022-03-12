using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class AktivostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktivnost",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OpisAktivnosti = table.Column<string>(nullable: true),
                    NazivAktivnosti = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivnost", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AktivnostZaposlenik",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(nullable: false),
                    AktivnostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AktivnostZaposlenik", x => new { x.AktivnostID, x.ZaposlenikID });
                    table.ForeignKey(
                        name: "FK_AktivnostZaposlenik_Aktivnost_AktivnostID",
                        column: x => x.AktivnostID,
                        principalTable: "Aktivnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AktivnostZaposlenik_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DijeteAktivnost",
                columns: table => new
                {
                    DijeteID = table.Column<int>(nullable: false),
                    AktivnostID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DijeteAktivnost", x => new { x.DijeteID, x.AktivnostID });
                    table.ForeignKey(
                        name: "FK_DijeteAktivnost_Aktivnost_AktivnostID",
                        column: x => x.AktivnostID,
                        principalTable: "Aktivnost",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DijeteAktivnost_Dijete_DijeteID",
                        column: x => x.DijeteID,
                        principalTable: "Dijete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AktivnostZaposlenik_ZaposlenikID",
                table: "AktivnostZaposlenik",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_DijeteAktivnost_AktivnostID",
                table: "DijeteAktivnost",
                column: "AktivnostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AktivnostZaposlenik");

            migrationBuilder.DropTable(
                name: "DijeteAktivnost");

            migrationBuilder.DropTable(
                name: "Aktivnost");
        }
    }
}
