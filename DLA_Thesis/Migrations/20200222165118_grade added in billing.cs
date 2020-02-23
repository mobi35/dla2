using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class gradeaddedinbilling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Bilings",
                newName: "Grade");

            migrationBuilder.AddColumn<string>(
                name: "LRN",
                table: "Bilings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LRN",
                table: "Bilings");

            migrationBuilder.RenameColumn(
                name: "Grade",
                table: "Bilings",
                newName: "StudentID");
        }
    }
}
