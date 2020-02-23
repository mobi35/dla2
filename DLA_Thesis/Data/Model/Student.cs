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
        public string LRN { get; set; }
        public string Password { get; set; }
        public string StudentCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameExtension { get; set; }

        //If Student
        public int CurrentGrade { get; set; }

        public string Address { get; set; }

        public string Barangay { get; set; }

        public string City { get; set; }
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public string Schools { get; set; }

        public string Phonenumber { get; set; }

        public string EmailAddress { get; set; }


        public string FatherFirstName { get; set; }
 
        public string FatherLastName { get; set; }

        public string FatherOccupation { get; set; }

        public string FatherNumber { get; set; }

        public string MotherFirstName { get; set; }
  
        public string MotherLastName { get; set; }

        public string MotherOccupation { get; set; }
        public string MotherNumber { get; set; }

        public string GuardianFirstName { get; set; }
    
        public string GuardianLastName { get; set; }
        public string GuardianNumber { get; set; }

        public string GuardianOccupation { get; set; }




        [NotMapped]
        public IFormFile Image { get; set; }

        public string ImageName { get; set; }

        //REQUIREMENTS
        [NotMapped]
        public IFormFile BirthCertificate { get; set; }
        [NotMapped]
        public IFormFile Form137 { get; set; }
        [NotMapped]
        public IFormFile Form138 { get; set; }
        [NotMapped]
        public IFormFile GoodMoral { get; set; }

        public string BirthCertificateName { get; set; }

        public string Form137Name { get; set; }
        public string Form138Name { get; set; }
        public string GoodMoralName { get; set; }



        public float Balance { get; set; }

        public string Status { get; set; }

        
        public int SectionID { get; set; }



    }
}
