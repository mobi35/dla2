using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Grades
    {
        public int GradesID { get; set; }
        public string SubjectCode { get; set; }
        public float Grade { get; set; }
        public int Grading { get; set; }
        public string StudentCode { get; set; }
        public string TeacherCode { get; set; }

    }
}
