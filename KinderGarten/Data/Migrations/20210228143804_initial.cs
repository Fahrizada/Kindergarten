using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Drzava",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drzava", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StrucnaSprema",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StrucnaSprema", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Adresa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrstaUplate",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrsta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaUplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zanimanje",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zanimanje", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    PostanskiBroj = table.Column<string>(nullable: true),
                    DrzavaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Grad_Drzava_DrzavaID",
                        column: x => x.DrzavaID,
                        principalTable: "Drzava",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dijete",
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
                    Napomena = table.Column<string>(nullable: true),
                    PosebnePotrebe = table.Column<bool>(nullable: false),
                    GrupaID = table.Column<int>(nullable: false),
                    PutanjaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijete", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dijete_Grupa_GrupaID",
                        column: x => x.GrupaID,
                        principalTable: "Grupa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OvlastenaOsoba",
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
                    Zaposlen = table.Column<bool>(nullable: false),
                    Aktivan = table.Column<bool>(nullable: false),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    PutanjaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OvlastenaOsoba", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OvlastenaOsoba_StrucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "StrucnaSprema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zaposlenik",
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
                    ZanimanjeID = table.Column<int>(nullable: false),
                    StrucnaSpremaID = table.Column<int>(nullable: false),
                    PutanjaSlike = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zaposlenik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_StrucnaSprema_StrucnaSpremaID",
                        column: x => x.StrucnaSpremaID,
                        principalTable: "StrucnaSprema",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zaposlenik_Zanimanje_ZanimanjeID",
                        column: x => x.ZanimanjeID,
                        principalTable: "Zanimanje",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seminar",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VrijemeSeminaraOd = table.Column<DateTime>(nullable: false),
                    VrijemeSeminaraDo = table.Column<DateTime>(nullable: false),
                    Certifikat = table.Column<bool>(nullable: false),
                    GradID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seminar_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DijeteOvlastenaOsoba",
                columns: table => new
                {
                    DijeteID = table.Column<int>(nullable: false),
                    OvlastenaOsobaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DijeteOvlastenaOsoba", x => new { x.DijeteID, x.OvlastenaOsobaID });
                    table.ForeignKey(
                        name: "FK_DijeteOvlastenaOsoba_Dijete_DijeteID",
                        column: x => x.DijeteID,
                        principalTable: "Dijete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DijeteOvlastenaOsoba_OvlastenaOsoba_OvlastenaOsobaID",
                        column: x => x.OvlastenaOsobaID,
                        principalTable: "OvlastenaOsoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uplata",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumUplate = table.Column<DateTime>(nullable: false),
                    Iznos = table.Column<decimal>(nullable: false),
                    DijeteID = table.Column<int>(nullable: false),
                    OvlastenaOsobaID = table.Column<int>(nullable: false),
                    VrstaUplateID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uplata", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Uplata_Dijete_DijeteID",
                        column: x => x.DijeteID,
                        principalTable: "Dijete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplata_OvlastenaOsoba_OvlastenaOsobaID",
                        column: x => x.OvlastenaOsobaID,
                        principalTable: "OvlastenaOsoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uplata_VrstaUplate_VrstaUplateID",
                        column: x => x.VrstaUplateID,
                        principalTable: "VrstaUplate",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izlet",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumIzletaOd = table.Column<DateTime>(nullable: false),
                    DatumIzletaDo = table.Column<DateTime>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false),
                    Lokacija = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izlet", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Izlet_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RadniList",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Zaposlenik1ID = table.Column<int>(nullable: false),
                    Zaposlenik2ID = table.Column<int>(nullable: false),
                    GrupaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RadniList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RadniList_Grupa_GrupaID",
                        column: x => x.GrupaID,
                        principalTable: "Grupa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadniList_Zaposlenik_Zaposlenik1ID",
                        column: x => x.Zaposlenik1ID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RadniList_Zaposlenik_Zaposlenik2ID",
                        column: x => x.Zaposlenik2ID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ZaposlenikSeminar",
                columns: table => new
                {
                    ZaposlenikID = table.Column<int>(nullable: false),
                    SeminarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZaposlenikSeminar", x => new { x.ZaposlenikID, x.SeminarID });
                    table.ForeignKey(
                        name: "FK_ZaposlenikSeminar_Seminar_SeminarID",
                        column: x => x.SeminarID,
                        principalTable: "Seminar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZaposlenikSeminar_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DijeteIzlet",
                columns: table => new
                {
                    DijeteID = table.Column<int>(nullable: false),
                    IzletID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DijeteIzlet", x => new { x.DijeteID, x.IzletID });
                    table.ForeignKey(
                        name: "FK_DijeteIzlet_Dijete_DijeteID",
                        column: x => x.DijeteID,
                        principalTable: "Dijete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DijeteIzlet_Izlet_IzletID",
                        column: x => x.IzletID,
                        principalTable: "Izlet",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Evidencija",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vrijeme = table.Column<DateTime>(nullable: false),
                    Odlazak = table.Column<bool>(nullable: false),
                    ZaposlenikID = table.Column<int>(nullable: false),
                    RadniListID = table.Column<int>(nullable: false),
                    OvlastenaOsobaID = table.Column<int>(nullable: false),
                    DijeteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evidencija", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Evidencija_Dijete_DijeteID",
                        column: x => x.DijeteID,
                        principalTable: "Dijete",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evidencija_OvlastenaOsoba_OvlastenaOsobaID",
                        column: x => x.OvlastenaOsobaID,
                        principalTable: "OvlastenaOsoba",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Evidencija_RadniList_RadniListID",
                        column: x => x.RadniListID,
                        principalTable: "RadniList",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Evidencija_Zaposlenik_ZaposlenikID",
                        column: x => x.ZaposlenikID,
                        principalTable: "Zaposlenik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dijete_GrupaID",
                table: "Dijete",
                column: "GrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_DijeteIzlet_IzletID",
                table: "DijeteIzlet",
                column: "IzletID");

            migrationBuilder.CreateIndex(
                name: "IX_DijeteOvlastenaOsoba_OvlastenaOsobaID",
                table: "DijeteOvlastenaOsoba",
                column: "OvlastenaOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_DijeteID",
                table: "Evidencija",
                column: "DijeteID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_OvlastenaOsobaID",
                table: "Evidencija",
                column: "OvlastenaOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_RadniListID",
                table: "Evidencija",
                column: "RadniListID");

            migrationBuilder.CreateIndex(
                name: "IX_Evidencija_ZaposlenikID",
                table: "Evidencija",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_Grad_DrzavaID",
                table: "Grad",
                column: "DrzavaID");

            migrationBuilder.CreateIndex(
                name: "IX_Izlet_ZaposlenikID",
                table: "Izlet",
                column: "ZaposlenikID");

            migrationBuilder.CreateIndex(
                name: "IX_OvlastenaOsoba_StrucnaSpremaID",
                table: "OvlastenaOsoba",
                column: "StrucnaSpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniList_GrupaID",
                table: "RadniList",
                column: "GrupaID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniList_Zaposlenik1ID",
                table: "RadniList",
                column: "Zaposlenik1ID");

            migrationBuilder.CreateIndex(
                name: "IX_RadniList_Zaposlenik2ID",
                table: "RadniList",
                column: "Zaposlenik2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Seminar_GradID",
                table: "Seminar",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_DijeteID",
                table: "Uplata",
                column: "DijeteID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_OvlastenaOsobaID",
                table: "Uplata",
                column: "OvlastenaOsobaID");

            migrationBuilder.CreateIndex(
                name: "IX_Uplata_VrstaUplateID",
                table: "Uplata",
                column: "VrstaUplateID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_StrucnaSpremaID",
                table: "Zaposlenik",
                column: "StrucnaSpremaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zaposlenik_ZanimanjeID",
                table: "Zaposlenik",
                column: "ZanimanjeID");

            migrationBuilder.CreateIndex(
                name: "IX_ZaposlenikSeminar_SeminarID",
                table: "ZaposlenikSeminar",
                column: "SeminarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DijeteIzlet");

            migrationBuilder.DropTable(
                name: "DijeteOvlastenaOsoba");

            migrationBuilder.DropTable(
                name: "Evidencija");

            migrationBuilder.DropTable(
                name: "Uplata");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ZaposlenikSeminar");

            migrationBuilder.DropTable(
                name: "Izlet");

            migrationBuilder.DropTable(
                name: "RadniList");

            migrationBuilder.DropTable(
                name: "Dijete");

            migrationBuilder.DropTable(
                name: "OvlastenaOsoba");

            migrationBuilder.DropTable(
                name: "VrstaUplate");

            migrationBuilder.DropTable(
                name: "Seminar");

            migrationBuilder.DropTable(
                name: "Zaposlenik");

            migrationBuilder.DropTable(
                name: "Grupa");

            migrationBuilder.DropTable(
                name: "Grad");

            migrationBuilder.DropTable(
                name: "StrucnaSprema");

            migrationBuilder.DropTable(
                name: "Zanimanje");

            migrationBuilder.DropTable(
                name: "Drzava");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }
    }
}
