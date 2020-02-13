using DLA_Thesis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class TeacherSectionViewModel
    {
        public List<Section> Section { get; set; }
        public List<Teacher> Teacher { get; set; }
    }
}
