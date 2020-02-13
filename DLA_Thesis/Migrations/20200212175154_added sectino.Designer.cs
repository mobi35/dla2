﻿// <auto-generated />
using System;
using DLA_Thesis.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DLA_Thesis.Migrations
{
    [DbContext(typeof(DLADBContext))]
    [Migration("20200212175154_added sectino")]
    partial class addedsectino
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("DateAdded");

                    b.Property<float>("GradeLevel");

                    b.Property<int>("Grading");

                    b.Property<string>("SectionID");

                    b.Property<string>("StudentLRN");

                    b.Property<string>("SubjectCode");

                    b.Property<float>("SubjectGrade");

                    b.Property<string>("TeacherEmail");

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

            modelBuilder.Entity("DLA_Thesis.Data.Model.Section", b =>
                {
                    b.Property<int>("SectionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adviser");

                    b.Property<int>("Grade");

                    b.Property<string>("SectionName");

                    b.Property<int>("SectionNumber");

                    b.HasKey("SectionID");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("DLA_Thesis.Data.Model.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<float>("Balance");

                    b.Property<string>("Barangay");

                    b.Property<string>("BirthCertificateName");

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("City");

                    b.Property<int>("CurrentGrade");

                    b.Property<string>("EmailAddress");

                    b.Property<string>("FatherFirstName");

                    b.Property<string>("FatherLastName");

                    b.Property<string>("FatherNumber");

                    b.Property<string>("FatherOccupation");

                    b.Property<string>("FirstName");

                    b.Property<string>("Form137Name");

                    b.Property<string>("Form138Name");

                    b.Property<string>("Gender");

                    b.Property<string>("GoodMoralName");

                    b.Property<string>("GuardianFirstName");

                    b.Property<string>("GuardianLastName");

                    b.Property<string>("GuardianNumber");

                    b.Property<string>("GuardianOccupation");

                    b.Property<string>("ImageName");

                    b.Property<string>("LRN");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<string>("MotherFirstName");

                    b.Property<string>("MotherLastName");

                    b.Property<string>("MotherNumber");

                    b.Property<string>("MotherOccupation");

                    b.Property<string>("NameExtension");

                    b.Property<string>("Password");

                    b.Property<string>("Phonenumber");

                    b.Property<string>("Schools");

                    b.Property<string>("Status");

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
