using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class ExcelGradeStructure
    {
        public string SubjectCode { get; set; }

        public int GradeLevel { get; set; }

        public int Grading { get; set; }
        public int Section { get; set; }

        public List<ExcelGrades> ExcelGrades { get; set; }
    }
}
