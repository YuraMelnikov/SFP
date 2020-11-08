using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_08 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageSpeed",
                table: "Qualification");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "Qualification",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "Time",
                table: "Qualification",
                type: "interval",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<float>(
                name: "AverageSpeed",
                table: "Qualification",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }
    }
}
