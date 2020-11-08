using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_08_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DNQ");

            migrationBuilder.DropTable(
                name: "Fail");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "Pit");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "GrandPrixResult",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AddColumn<string>(
                name: "Classification",
                table: "GrandPrixResult",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "GrandPrixResult",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Classification",
                table: "GrandPrixResult");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "GrandPrixResult");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "GrandPrixResult",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "DNQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNQ_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTypeFail = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fail_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fail_TypeFail_IdTypeFail",
                        column: x => x.IdTypeFail,
                        principalTable: "TypeFail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(type: "uuid", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fine_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pit",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(type: "uuid", nullable: false),
                    Lap = table.Column<int>(type: "integer", nullable: false),
                    Time = table.Column<TimeSpan>(type: "interval", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pit_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DNQ_IdGrandPrixResult",
                table: "DNQ",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdGrandPrixResult",
                table: "Fail",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdTypeFail",
                table: "Fail",
                column: "IdTypeFail");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_IdGrandPrixResult",
                table: "Fine",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Pit_IdGrandPrixResult",
                table: "Pit",
                column: "IdGrandPrixResult");
        }
    }
}
