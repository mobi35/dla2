using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Grade
    {
        [Key]
        public int GradesID { get; set; }
     
        public string StudentLRN { get; set; }
        public string TeacherEmail { get; set; }
        public string SectionID { get; set; }

        public string SubjectCode { get; set; }
        public float GradeLevel { get; set; }
        public int Grading { get; set; }
        public float SubjectGrade { get; set; }
        public DateTime DateAdded { get; set; }


    }
}
