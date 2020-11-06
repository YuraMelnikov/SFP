using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class Update2020_11_06_02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLap",
                table: "GrandPrix",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfLap",
                table: "GrandPrix");
        }
    }
}
