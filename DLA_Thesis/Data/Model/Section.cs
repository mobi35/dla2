using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Section
    {
        public int SectionID { get; set; }
        public int Grade { get; set; }
        public int SectionNumber { get; set; }
        public string SectionName { get; set; }
        public int TeacherID { get; set; }

    }
}
