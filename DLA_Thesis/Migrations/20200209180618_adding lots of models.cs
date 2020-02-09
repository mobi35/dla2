using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class addinglotsofmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MotherName",
                table: "Students",
                newName: "MotherNumber");

            migrationBuilder.RenameColumn(
                name: "GuardianName",
                table: "Students",
                newName: "MotherLastName");

            migrationBuilder.RenameColumn(
                name: "FatherName",
                table: "Students",
                newName: "MotherFirstName");

            migrationBuilder.AddColumn<string>(
                name: "Barangay",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthCertificateName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherFirstName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherLastName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FatherNumber",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Form137Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Form138Name",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GoodMoralName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianFirstName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianLastName",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GuardianNumber",
                table: "Students",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barangay",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthCertificateName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "FatherNumber",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Form137Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Form138Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GoodMoralName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianFirstName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianLastName",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GuardianNumber",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "MotherNumber",
                table: "Students",
                newName: "MotherName");

            migrationBuilder.RenameColumn(
                name: "MotherLastName",
                table: "Students",
                newName: "GuardianName");

            migrationBuilder.RenameColumn(
                name: "MotherFirstName",
                table: "Students",
                newName: "FatherName");
        }
    }
}
