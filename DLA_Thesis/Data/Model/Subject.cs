using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }


        public string Areas { get; set; }

        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Grade { get; set; }
        
    }
}
