using DLA_Thesis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class InvoiceModel
    {
        public Billing Billing { get; set; }
        public Fee Fee { get; set; }
        public Student Student { get; set; }

    }
}
