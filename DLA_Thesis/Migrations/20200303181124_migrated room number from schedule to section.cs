using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class migratedroomnumberfromscheduletosection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Schedules");

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Sections",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Sections");

            migrationBuilder.AddColumn<string>(
                name: "RoomNumber",
                table: "Schedules",
                nullable: true);
        }
    }
}
