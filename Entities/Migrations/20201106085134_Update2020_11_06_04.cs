using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_06_04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DescriptionGPResult_GrandPrixResult_IdGrandPrixResult",
                table: "DescriptionGPResult");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DescriptionGPResult",
                table: "DescriptionGPResult");

            migrationBuilder.RenameTable(
                name: "DescriptionGPResult",
                newName: "GrandPrixResultNote");

            migrationBuilder.RenameIndex(
                name: "IX_DescriptionGPResult_IdGrandPrixResult",
                table: "GrandPrixResultNote",
                newName: "IX_GrandPrixResultNote_IdGrandPrixResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GrandPrixResultNote",
                table: "GrandPrixResultNote",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GrandPrixResultNote_GrandPrixResult_IdGrandPrixResult",
                table: "GrandPrixResultNote",
                column: "IdGrandPrixResult",
                principalTable: "GrandPrixResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GrandPrixResultNote_GrandPrixResult_IdGrandPrixResult",
                table: "GrandPrixResultNote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GrandPrixResultNote",
                table: "GrandPrixResultNote");

            migrationBuilder.RenameTable(
                name: "GrandPrixResultNote",
                newName: "DescriptionGPResult");

            migrationBuilder.RenameIndex(
                name: "IX_GrandPrixResultNote_IdGrandPrixResult",
                table: "DescriptionGPResult",
                newName: "IX_DescriptionGPResult_IdGrandPrixResult");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DescriptionGPResult",
                table: "DescriptionGPResult",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DescriptionGPResult_GrandPrixResult_IdGrandPrixResult",
                table: "DescriptionGPResult",
                column: "IdGrandPrixResult",
                principalTable: "GrandPrixResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
