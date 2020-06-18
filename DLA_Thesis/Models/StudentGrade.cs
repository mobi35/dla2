using DLA_Thesis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class StudentGrade
    {
        public Student Student { get; set; }

        public float FirstGrading { get; set; }

        public float SecondGrading { get; set; }

        public float ThirdGrading { get; set; }

        public float FourthGrading { get; set; }
    }
}
