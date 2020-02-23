using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Fee
    {
        [Key]
        public int FeeID { get; set; }

        public string PaymentName { get; set; }

        public float PaymentPrice { get; set; }

        public string Status { get; set; }

        public int GradeLevel { get; set; }

    }
}
