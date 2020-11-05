using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Created : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Link = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
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
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NameRu = table.Column<string>(nullable: false),
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
                    IdImage = table.Column<Guid>(nullable: false)
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
                    FirstNameRus = table.Column<string>(nullable: false),
                    SecondNameRus = table.Column<string>(nullable: false),
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
                    Name = table.Column<string>(nullable: false),
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
                    Name = table.Column<string>(nullable: false),
                    NameRus = table.Column<string>(nullable: false)
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
                name: "Chassis",
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
                    table.PrimaryKey("PK_Chassis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chassis_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassis_Image_IdLivery",
                        column: x => x.IdLivery,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chassis_Manufacturer_IdManufacturer",
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
                name: "ManufacturerImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdManufacturer = table.Column<Guid>(nullable: false)
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
                name: "RacerImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdRacer = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RacerImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RacerImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RacerImg_Racer_IdRacer",
                        column: x => x.IdRacer,
                        principalTable: "Racer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeamImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdTeam = table.Column<Guid>(nullable: false)
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

            migrationBuilder.CreateTable(
                name: "TeamName",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTeam = table.Column<Guid>(nullable: false),
                    IdSeason = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamName_Season_IdSeason",
                        column: x => x.IdSeason,
                        principalTable: "Season",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamName_Team_IdTeam",
                        column: x => x.IdTeam,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackСonfiguration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTrack = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Length = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackСonfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackСonfiguration_Image_IdImage",
                        column: x => x.IdImage,
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
                name: "ChassisImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdChassi = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassisImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChassisImg_Chassis_IdChassi",
                        column: x => x.IdChassi,
                        principalTable: "Chassis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChassisImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EngineImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdEngine = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EngineImg_Engine_IdEngine",
                        column: x => x.IdEngine,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrix",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdTrackСonfiguration = table.Column<Guid>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    NumberInSeason = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    Weather = table.Column<string>(nullable: false),
                    PercentDistance = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrix", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrix_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrix_TrackСonfiguration_IdTrackСonfiguration",
                        column: x => x.IdTrackСonfiguration,
                        principalTable: "TrackСonfiguration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrandPrixImg",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdImage = table.Column<Guid>(nullable: false),
                    IdGrandPrix = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixImg", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixImg_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrandPrixImg_Image_IdImage",
                        column: x => x.IdImage,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Participant",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrix = table.Column<Guid>(nullable: false),
                    Number = table.Column<string>(nullable: false),
                    IdTeam = table.Column<Guid>(nullable: false),
                    IdChassis = table.Column<Guid>(nullable: false),
                    IdEngine = table.Column<Guid>(nullable: false),
                    IdRacer = table.Column<Guid>(nullable: false),
                    IdTyre = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Participant_Chassis_IdChassis",
                        column: x => x.IdChassis,
                        principalTable: "Chassis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_Engine_IdEngine",
                        column: x => x.IdEngine,
                        principalTable: "Engine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Participant_GrandPrix_IdGrandPrix",
                        column: x => x.IdGrandPrix,
                        principalTable: "GrandPrix",
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
                name: "GrandPrixResult",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdParticipant = table.Column<Guid>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AverageSpeed = table.Column<float>(nullable: false),
                    Lap = table.Column<int>(nullable: false),
                    Points = table.Column<float>(nullable: false),
                    Position = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrandPrixResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrandPrixResult_Participant_IdParticipant",
                        column: x => x.IdParticipant,
                        principalTable: "Participant",
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
                    AverageSpeed = table.Column<float>(nullable: false),
                    Points = table.Column<float>(nullable: false)
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
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DescriptionGPResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DescriptionGPResult_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DNQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: false)
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
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    IdTypeFail = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: false)
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
                name: "FastLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    Lap = table.Column<int>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false),
                    AverageSpeed = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FastLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FastLap_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fine",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    Note = table.Column<string>(nullable: false)
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
                name: "LeaderLap",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    First = table.Column<int>(nullable: false),
                    Last = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaderLap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaderLap_GrandPrixResult_IdGrandPrixResult",
                        column: x => x.IdGrandPrixResult,
                        principalTable: "GrandPrixResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdGrandPrixResult = table.Column<Guid>(nullable: false),
                    Lap = table.Column<int>(nullable: false),
                    Time = table.Column<TimeSpan>(nullable: false)
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
                name: "IX_Chassis_IdImage",
                table: "Chassis",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_IdLivery",
                table: "Chassis",
                column: "IdLivery");

            migrationBuilder.CreateIndex(
                name: "IX_Chassis_IdManufacturer",
                table: "Chassis",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_ChassisImg_IdChassi",
                table: "ChassisImg",
                column: "IdChassi");

            migrationBuilder.CreateIndex(
                name: "IX_ChassisImg_IdImage",
                table: "ChassisImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Country_IdImage",
                table: "Country",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_DescriptionGPResult_IdGrandPrixResult",
                table: "DescriptionGPResult",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_DNQ_IdGrandPrixResult",
                table: "DNQ",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdImage",
                table: "Engine",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_IdManufacturer",
                table: "Engine",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_EngineImg_IdEngine",
                table: "EngineImg",
                column: "IdEngine");

            migrationBuilder.CreateIndex(
                name: "IX_EngineImg_IdImage",
                table: "EngineImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdGrandPrixResult",
                table: "Fail",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fail_IdTypeFail",
                table: "Fail",
                column: "IdTypeFail");

            migrationBuilder.CreateIndex(
                name: "IX_FastLap_IdGrandPrixResult",
                table: "FastLap",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Fine_IdGrandPrixResult",
                table: "Fine",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdImage",
                table: "GrandPrix",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrix_IdTrackСonfiguration",
                table: "GrandPrix",
                column: "IdTrackСonfiguration");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixImg_IdGrandPrix",
                table: "GrandPrixImg",
                column: "IdGrandPrix");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixImg_IdImage",
                table: "GrandPrixImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_GrandPrixResult_IdParticipant",
                table: "GrandPrixResult",
                column: "IdParticipant");

            migrationBuilder.CreateIndex(
                name: "IX_LeaderLap_IdGrandPrixResult",
                table: "LeaderLap",
                column: "IdGrandPrixResult");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdCountry",
                table: "Manufacturer",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturer_IdImage",
                table: "Manufacturer",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerImg_IdImage",
                table: "ManufacturerImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_ManufacturerImg_IdManufacturer",
                table: "ManufacturerImg",
                column: "IdManufacturer");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdChassis",
                table: "Participant",
                column: "IdChassis");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdEngine",
                table: "Participant",
                column: "IdEngine");

            migrationBuilder.CreateIndex(
                name: "IX_Participant_IdGrandPrix",
                table: "Participant",
                column: "IdGrandPrix");

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
                name: "IX_Pit_IdGrandPrixResult",
                table: "Pit",
                column: "IdGrandPrixResult");

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
                name: "IX_RacerImg_IdImage",
                table: "RacerImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_RacerImg_IdRacer",
                table: "RacerImg",
                column: "IdRacer");

            migrationBuilder.CreateIndex(
                name: "IX_Season_IdImage",
                table: "Season",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdCountry",
                table: "Team",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IdImage",
                table: "Team",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TeamImg_IdImage",
                table: "TeamImg",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TeamImg_IdTeam",
                table: "TeamImg",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdSeason",
                table: "TeamName",
                column: "IdSeason");

            migrationBuilder.CreateIndex(
                name: "IX_TeamName_IdTeam",
                table: "TeamName",
                column: "IdTeam");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdCountry",
                table: "Track",
                column: "IdCountry");

            migrationBuilder.CreateIndex(
                name: "IX_Track_IdImage",
                table: "Track",
                column: "IdImage");

            migrationBuilder.CreateIndex(
                name: "IX_TrackСonfiguration_IdImage",
                table: "TrackСonfiguration",
                column: "IdImage");

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
                name: "ChassisImg");

            migrationBuilder.DropTable(
                name: "DescriptionGPResult");

            migrationBuilder.DropTable(
                name: "DNQ");

            migrationBuilder.DropTable(
                name: "EngineImg");

            migrationBuilder.DropTable(
                name: "Fail");

            migrationBuilder.DropTable(
                name: "FastLap");

            migrationBuilder.DropTable(
                name: "Fine");

            migrationBuilder.DropTable(
                name: "GrandPrixImg");

            migrationBuilder.DropTable(
                name: "LeaderLap");

            migrationBuilder.DropTable(
                name: "ManufacturerImg");

            migrationBuilder.DropTable(
                name: "Pit");

            migrationBuilder.DropTable(
                name: "Qualification");

            migrationBuilder.DropTable(
                name: "RacerImg");

            migrationBuilder.DropTable(
                name: "TeamImg");

            migrationBuilder.DropTable(
                name: "TeamName");

            migrationBuilder.DropTable(
                name: "TypeFail");

            migrationBuilder.DropTable(
                name: "GrandPrixResult");

            migrationBuilder.DropTable(
                name: "Season");

            migrationBuilder.DropTable(
                name: "Participant");

            migrationBuilder.DropTable(
                name: "Chassis");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "GrandPrix");

            migrationBuilder.DropTable(
                name: "Racer");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Tyre");

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
