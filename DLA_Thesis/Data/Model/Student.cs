using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public int LRN { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameExtension { get; set; }

        //If Student
        public int CurrentGrade { get; set; }

        public string Address { get; set; }
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Schools { get; set; }

        public string Phonenumber { get; set; }

        public string EmailAddress { get; set; }


        public string FatherName { get; set; }

        public string FatherOccupation { get; set; }

        public string MotherName { get; set; }

        public string MotherOccupation { get; set; }

        public string GuardianName { get; set; }

        public string GuardianOccupation { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }









    }
}
