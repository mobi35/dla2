using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class GradeRegistrationFileStructure
    {
        public int ScheduleID { get; set; }

        public int Grading { get; set; }

        public IFormFile ExcelFile { get; set; }

        public string Teacher { get; set; }
    }
}
