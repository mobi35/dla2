using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DLA_Thesis.Migrations
{
    public partial class addedsectino : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TeacherCode",
                table: "Grades",
                newName: "TeacherEmail");

            migrationBuilder.RenameColumn(
                name: "StudentCode",
                table: "Grades",
                newName: "StudentLRN");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Grades",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SectionID",
                table: "Grades",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "SubjectGrade",
                table: "Grades",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Grade = table.Column<int>(nullable: false),
                    SectionNumber = table.Column<int>(nullable: false),
                    SectionName = table.Column<string>(nullable: true),
                    Adviser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SectionID",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "SubjectGrade",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "TeacherEmail",
                table: "Grades",
                newName: "TeacherCode");

            migrationBuilder.RenameColumn(
                name: "StudentLRN",
                table: "Grades",
                newName: "StudentCode");
        }
    }
}
