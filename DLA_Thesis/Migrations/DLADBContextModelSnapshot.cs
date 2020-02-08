﻿// <auto-generated />
using System;
using DLA_Thesis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DLA_Thesis.Migrations
{
    [DbContext(typeof(DLADBContext))]
    partial class DLADBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DLA_Thesis.Data.Model.Grade", b =>
                {
                    b.Property<int>("GradesID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("GradeLevel");

                    b.Property<int>("Grading");

                    b.Property<string>("StudentCode");

                    b.Property<string>("SubjectCode");

                    b.Property<string>("TeacherCode");

                    b.HasKey("GradesID");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("DLA_Thesis.Data.Model.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Day");

                    b.HasKey("ScheduleID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("DLA_Thesis.Data.Model.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<int>("CurrentGrade");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FatherName");

                    b.Property<string>("FatherOccupation");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("GuardianName");

                    b.Property<string>("GuardianOccupation");

                    b.Property<string>("ImageName");

                    b.Property<int>("LRN");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("MotherName");

                    b.Property<string>("MotherOccupation");

                    b.Property<string>("NameExtension");

                    b.Property<string>("Password");

                    b.Property<string>("Phonenumber");

                    b.Property<string>("Schools");

                    b.Property<string>("StudentCode");

                    b.HasKey("StudentID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DLA_Thesis.Data.Model.Subject", b =>
                {
                    b.Property<int>("SubjectID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade");

                    b.Property<string>("SubjectCode");

                    b.Property<string>("SubjectName");

                    b.HasKey("SubjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("DLA_Thesis.Data.Model.Teacher", b =>
                {
                    b.Property<int>("TeacherID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Courses");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("ImageName");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("Password");

                    b.Property<string>("Schools");

                    b.Property<string>("Skills");

                    b.Property<string>("TeacherCode");

                    b.Property<string>("UserLevel");

                    b.HasKey("TeacherID");

                    b.ToTable("Teachers");
                });
#pragma warning restore 612, 618
        }
    }
}
