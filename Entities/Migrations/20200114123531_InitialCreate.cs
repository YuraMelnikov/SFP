using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livery",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeCalculate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCalculate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeDNQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeDNQ", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeFinish",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeFinish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Season",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdTypeCalculate = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Season", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Season_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Season_TypeCalculate_IdTypeCalculate",
                        column: x => x.IdTypeCalculate,
                        principalTable: "TypeCalculate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCountry = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Manufacturer_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCountry = table.Column<Guid>(nullable: false),
                    Born = table.Column<DateTime>(nullable: false),
                    BornIn = table.Column<string>(nullable: false),
                    Dead = table.Column<DateTime>(nullable: true),
                    DeadIn = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    SecondName = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    TextData = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Racer_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Racer_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCountry = table.Column<Guid>(nullable: false),
                    ShortName = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Team_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Track",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdCountry = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Track", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Track_Country_IdCountry",
                        column: x => x.IdCountry,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Track_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdSeasonStart = table.Column<Guid>(nullable: false),
                    IdSeasonFinish = table.Column<Guid>(nullable: false),
                    LongName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamName_Season_IdSeasonFinish",
                        column: x => x.IdSeasonFinish,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamName_Season_IdSeasonStart",
                        column: x => x.IdSeasonStart,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chassi",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdManufacturer = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdLivery = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chassi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chassi_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassi_Livery_IdLivery",
                        column: x => x.IdLivery,
                        principalTable: "Livery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassi_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdManufacturer = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engine_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Engine_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tyre",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdManufacturer = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tyre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tyre_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tyre_Manufacturer_IdManufacturer",
                        column: x => x.IdManufacturer,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackСonfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTrack = table.Column<Guid>(nullable: false),
                    IdImageGpConfiguration = table.Column<Guid>(nullable: false),
                    Length = table.Column<float>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackСonfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackСonfiguration_Image_IdImageGpConfiguration",
                        column: x => x.IdImageGpConfiguration,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackСonfiguration_Track_IdTrack",
                        column: x => x.IdTrack,
                        principalTable: "Track",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GP",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTrackСonfiguration = table.Column<Guid>(nullable: false),
                    Num = table.Column<int>(nullable: false),
                    NumInSeason = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Weather = table.Column<string>(nullable: false),
                    PercentDistance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GP", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GP_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GP_TrackСonfiguration_IdTrackСonfiguration",
                        column: x => x.IdTrackСonfiguration,
                        principalTable: "TrackСonfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGp = table.Column<Guid>(nullable: false),
                    Num = table.Column<string>(nullable: false),
                    IdTeam = table.Column<Guid>(nullable: false),
                    IdChassi = table.Column<Guid>(nullable: false),
                    IdEngine = table.Column<Guid>(nullable: false),
                    IdRacer = table.Column<Guid>(nullable: false),
                    IdTyre = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Chassi_IdChassi",
                        column: x => x.IdChassi,
                        principalTable: "Chassi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Engine_IdEngine",
                        column: x => x.IdEngine,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_GP_IdGp",
                        column: x => x.IdGp,
                        principalTable: "GP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Tyre_IdTyre",
                        column: x => x.IdTyre,
                        principalTable: "Tyre",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GPResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdParticipant = table.Column<Guid>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AverageSpeed = table.Column<float>(nullable: false),
                    IdTypeFinish = table.Column<Guid>(nullable: false),
                    Lap = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPResult_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GPResult_TypeFinish_IdTypeFinish",
                        column: x => x.IdTypeFinish,
                        principalTable: "TypeFinish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Qualification",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdParticipant = table.Column<Guid>(nullable: false),
                    Position = table.Column<int>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AverageSpeed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Qualification_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DescriptionGPResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionGPResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionGPResult_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DNQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    IdTypeDnq = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DNQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DNQ_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DNQ_TypeDNQ_IdTypeDnq",
                        column: x => x.IdTypeDnq,
                        principalTable: "TypeDNQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    IdTypeFail = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fail_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
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
                name: "FastLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    Lap = table.Column<int>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AverageSpeed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FastLap_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fine_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaderLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    First = table.Column<int>(nullable: false),
                    Last = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderLap_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGpResult = table.Column<Guid>(nullable: false),
                    Lap = table.Column<int>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pit_GPResult_IdGpResult",
                        column: x => x.IdGpResult,
                        principalTable: "GPResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chassi_IdImage",
                table: "Chassi",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Chassi_IdLivery",
                table: "Chassi",
                column: "IdLivery");

            migrationBuilder.CreateIndex(
                name: "IX_Chassi_IdManufacturer",
                table: "Chassi",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdImage",
                table: "Country",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionGPResult_IdGpResult",
                table: "DescriptionGPResult",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_DNQ_IdGpResult",
                table: "DNQ",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_DNQ_IdTypeDnq",
                table: "DNQ",
                column: "IdTypeDnq");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdImage",
                table: "Engine",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdManufacturer",
                table: "Engine",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdGpResult",
                table: "Fail",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdTypeFail",
                table: "Fail",
                column: "IdTypeFail");

            migrationBuilder.CreateIndex(
                name: "IX_FastLap_IdGpResult",
                table: "FastLap",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_IdGpResult",
                table: "Fine",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_GP_IdImage",
                table: "GP",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_GP_IdTrackСonfiguration",
                table: "GP",
                column: "IdTrackСonfiguration");

            migrationBuilder.CreateIndex(
                name: "IX_GPResult_IdParticipant",
                table: "GPResult",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_GPResult_IdTypeFinish",
                table: "GPResult",
                column: "IdTypeFinish");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderLap_IdGpResult",
                table: "LeaderLap",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdCountry",
                table: "Manufacturer",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdImage",
                table: "Manufacturer",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdChassi",
                table: "Participant",
                column: "IdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdEngine",
                table: "Participant",
                column: "IdEngine");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdGp",
                table: "Participant",
                column: "IdGp");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdRacer",
                table: "Participant",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdTeam",
                table: "Participant",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdTyre",
                table: "Participant",
                column: "IdTyre");

            migrationBuilder.CreateIndex(
                name: "IX_Pit_IdGpResult",
                table: "Pit",
                column: "IdGpResult");

            migrationBuilder.CreateIndex(
                name: "IX_Qualification_IdParticipant",
                table: "Qualification",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_Racer_IdCountry",
                table: "Racer",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Racer_IdImage",
                table: "Racer",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Season_IdImage",
                table: "Season",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Season_IdTypeCalculate",
                table: "Season",
                column: "IdTypeCalculate");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdCountry",
                table: "Team",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdImage",
                table: "Team",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdSeasonFinish",
                table: "TeamName",
                column: "IdSeasonFinish");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdSeasonStart",
                table: "TeamName",
                column: "IdSeasonStart");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdCountry",
                table: "Track",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdImage",
                table: "Track",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TrackСonfiguration_IdImageGpConfiguration",
                table: "TrackСonfiguration",
                column: "IdImageGpConfiguration");

            migrationBuilder.CreateIndex(
                name: "IX_TrackСonfiguration_IdTrack",
                table: "TrackСonfiguration",
                column: "IdTrack");

            migrationBuilder.CreateIndex(
                name: "IX_Tyre_IdImage",
                table: "Tyre",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Tyre_IdManufacturer",
                table: "Tyre",
                column: "IdManufacturer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DescriptionGPResult");

            migrationBuilder.DropTable(
                name: "DNQ");

            migrationBuilder.DropTable(
                name: "Fail");

            migrationBuilder.DropTable(
                name: "FastLap");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "LeaderLap");

            migrationBuilder.DropTable(
                name: "Pit");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "TeamName");

            migrationBuilder.DropTable(
                name: "TypeDNQ");

            migrationBuilder.DropTable(
                name: "TypeFail");

            migrationBuilder.DropTable(
                name: "GPResult");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "TypeFinish");

            migrationBuilder.DropTable(
                name: "TypeCalculate");

            migrationBuilder.DropTable(
                name: "Chassi");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "GP");

            migrationBuilder.DropTable(
                name: "Racer");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Tyre");

            migrationBuilder.DropTable(
                name: "Livery");

            migrationBuilder.DropTable(
                name: "TrackСonfiguration");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "Track");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Image");
        }
    }
}
