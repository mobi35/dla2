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
        public string Day { get; set; }
     
     
    }
}
