using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Teacher
    {

        [Key]
        public int TeacherID { get; set; }
        public string TeacherCode { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Schools { get; set; }
        public string Skills { get; set; }
        public string Courses { get; set; }
        public string Email { get; set; }
        public string UserLevel { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }


    }
}
