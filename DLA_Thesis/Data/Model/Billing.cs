using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model
{
    public class Billing
    {
        [Key]
        public int BillingID { get; set; }

        public string LRN { get; set; }

        public int Grade { get; set; }
        public float Payment { get; set; }

        public int FeeID { get; set; }

        public string Status { get; set; }

        public DateTime BilledDate { get; set; }
        
    }
}
