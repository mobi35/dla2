using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Room
    {
        [Key]
        public int RoomID { get; set; }

        public string RoomNumber { get; set; }
        public string Capacity { get; set; }
        public int SectionID { get; set; }
    }
}
