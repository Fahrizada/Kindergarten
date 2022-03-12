using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KinderGarten.Data.Migrations
{
    public partial class AktivostModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DatumAktivnosti",
                table: "Aktivnost",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatumAktivnosti",
                table: "Aktivnost");
        }
    }
}
