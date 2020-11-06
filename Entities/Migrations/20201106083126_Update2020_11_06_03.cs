using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_06_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdSeason",
                table: "GrandPrix",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdSeason",
                table: "GrandPrix",
                column: "IdSeason");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrix_Season_IdSeason",
                table: "GrandPrix",
                column: "IdSeason",
                principalTable: "Season",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrix_Season_IdSeason",
                table: "GrandPrix");

            migrationBuilder.DropIndex(
                name: "IX_GrandPrix_IdSeason",
                table: "GrandPrix");

            migrationBuilder.DropColumn(
                name: "IdSeason",
                table: "GrandPrix");
        }
    }
}
