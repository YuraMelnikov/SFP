using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020111101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManufacturerImg");

            migrationBuilder.DropTable(
                name: "TeamImg");

            migrationBuilder.CreateTable(
                name: "ParticipantImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdParticipant = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipantImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipantImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipantImg_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantImg_IdImage",
                table: "ParticipantImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipantImg_IdParticipant",
                table: "ParticipantImg",
                column: "IdParticipant");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipantImg");

            migrationBuilder.CreateTable(
                name: "ManufacturerImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    IdManufacturer = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManufacturerImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManufacturerImg_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdImage = table.Column<Guid>(type: "uuid", nullable: false),
                    IdTeam = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamImg_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerImg_IdImage",
                table: "ManufacturerImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerImg_IdManufacturer",
                table: "ManufacturerImg",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_TeamImg_IdImage",
                table: "TeamImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TeamImg_IdTeam",
                table: "TeamImg",
                column: "IdTeam");
        }
    }
}
