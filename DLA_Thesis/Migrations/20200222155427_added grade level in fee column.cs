using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class addedgradelevelinfeecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GradeLevel",
                table: "Fees",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GradeLevel",
                table: "Fees");
        }
    }
}
