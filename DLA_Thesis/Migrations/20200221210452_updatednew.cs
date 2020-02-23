using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class updatednew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Sections");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "Sections");

            migrationBuilder.RenameColumn(
                name: "Day",
                table: "Schedules",
                newName: "SubjectName");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Grade",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SectionName",
                table: "Schedules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectionNumber",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Schedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "TeacherID",
                table: "Schedules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Grade",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SectionName",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "SectionNumber",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Schedules");

            migrationBuilder.DropColumn(
                name: "TeacherID",
                table: "Schedules");

            migrationBuilder.RenameColumn(
                name: "SubjectName",
                table: "Schedules",
                newName: "Day");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Sections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Sections",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Sections",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "Sections",
                nullable: true);
        }
    }
}
