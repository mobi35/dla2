using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public string TeacherCode { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Schools { get; set; }

        public string Skills { get; set; }

        public string Courses { get; set; }

    }
}
