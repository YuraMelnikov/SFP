using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_06_06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrandprixNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrix = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandprixNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandprixNote_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandprixNote_IdGrandPrix",
                table: "GrandprixNote",
                column: "IdGrandPrix");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrandprixNote");
        }
    }
}
