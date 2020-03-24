using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Schedule
    {
        [Key]
        public int ScheduleID { get; set; }
        public int Grade { get; set; }
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TeacherID { get; set; }
        public int Slot { get; set; }
        public string SubjectName { get; set; }

        public string Areas { get; set; }

    }
}
