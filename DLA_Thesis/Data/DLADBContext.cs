using DLA_Thesis.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data
{
    public class DLADBContext : DbContext
    {

        public DLADBContext(DbContextOptions<DLADBContext> options) : base(options)
        {
        }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Billing> Bilings { get; set; }

        public DbSet<SubjectArea> SubjectAreas { get; set; }
    }
}
