using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_10_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lap",
                table: "FastLap");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "FastLap",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<string>(
                name: "AverageSpeed",
                table: "FastLap",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "FastLap",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<float>(
                name: "AverageSpeed",
                table: "FastLap",
                type: "real",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "Lap",
                table: "FastLap",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
