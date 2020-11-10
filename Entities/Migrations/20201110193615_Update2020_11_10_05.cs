using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_10_05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderLap_GrandPrixResult_IdGrandPrixResult",
                table: "LeaderLap");

            migrationBuilder.DropIndex(
                name: "IX_LeaderLap_IdGrandPrixResult",
                table: "LeaderLap");

            migrationBuilder.DropColumn(
                name: "IdGrandPrixResult",
                table: "LeaderLap");

            migrationBuilder.AddColumn<Guid>(
                name: "IdParticipant",
                table: "LeaderLap",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LeaderLap_IdParticipant",
                table: "LeaderLap",
                column: "IdParticipant");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderLap_Participant_IdParticipant",
                table: "LeaderLap",
                column: "IdParticipant",
                principalTable: "Participant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaderLap_Participant_IdParticipant",
                table: "LeaderLap");

            migrationBuilder.DropIndex(
                name: "IX_LeaderLap_IdParticipant",
                table: "LeaderLap");

            migrationBuilder.DropColumn(
                name: "IdParticipant",
                table: "LeaderLap");

            migrationBuilder.AddColumn<Guid>(
                name: "IdGrandPrixResult",
                table: "LeaderLap",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LeaderLap_IdGrandPrixResult",
                table: "LeaderLap",
                column: "IdGrandPrixResult");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaderLap_GrandPrixResult_IdGrandPrixResult",
                table: "LeaderLap",
                column: "IdGrandPrixResult",
                principalTable: "GrandPrixResult",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
