using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_10_03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FastLap_GrandPrixResult_IdGrandPrixResult",
                table: "FastLap");

            migrationBuilder.DropIndex(
                name: "IX_FastLap_IdGrandPrixResult",
                table: "FastLap");

            migrationBuilder.DropColumn(
                name: "IdGrandPrixResult",
                table: "FastLap");

            migrationBuilder.AddColumn<Guid>(
                name: "IdParticipant",
                table: "FastLap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FastLap_IdParticipant",
                table: "FastLap",
                column: "IdParticipant");

            migrationBuilder.AddForeignKey(
                name: "FK_FastLap_Participant_IdParticipant",
                table: "FastLap",
                column: "IdParticipant",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FastLap_Participant_IdParticipant",
                table: "FastLap");

            migrationBuilder.DropIndex(
                name: "IX_FastLap_IdParticipant",
                table: "FastLap");

            migrationBuilder.DropColumn(
                name: "IdParticipant",
                table: "FastLap");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGrandPrixResult",
                table: "FastLap",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_FastLap_IdGrandPrixResult",
                table: "FastLap",
                column: "IdGrandPrixResult");

            migrationBuilder.AddForeignKey(
                name: "FK_FastLap_GrandPrixResult_IdGrandPrixResult",
                table: "FastLap",
                column: "IdGrandPrixResult",
                principalTable: "GrandPrixResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
