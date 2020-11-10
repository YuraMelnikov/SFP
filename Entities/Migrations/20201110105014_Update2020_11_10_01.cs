using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_10_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrandPrixResultNote");

            migrationBuilder.DropTable(
                name: "TypeFail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrandPrixResultNote",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixResultNote", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixResultNote_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeFail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFail", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixResultNote_IdGrandPrixResult",
                table: "GrandPrixResultNote",
                column: "IdGrandPrixResult");
        }
    }
}
