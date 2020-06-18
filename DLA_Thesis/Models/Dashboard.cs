using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Models
{
    public class Dashboard
    {

       public int NumberOfStudent {get; set; }
       public int NumberOfTeacher {get; set; }
       public int NumberOfEmployees {get; set; }
       public float TotalPayments {get; set; }
       public List<string>  PaymentsChartLabel {get; set; }
       public List<float> PaymentsChartValues {get; set; }


       public List<string> EnrolledPerSubjectLabelGrade7 {get; set; }
       public List<int> EnrolledPerSubjectValuesGrade7 { get; set; }

        public List<string> EnrolledPerSubjectLabelGrade8 { get; set; }
        public List<int> EnrolledPerSubjectValuesGrade8 { get; set; }

        public List<string> EnrolledPerSubjectLabelGrade9 { get; set; }
        public List<int> EnrolledPerSubjectValuesGrade9 { get; set; }

        public List<string> EnrolledPerSubjectLabelGrade10 { get; set; }
        public List<int> EnrolledPerSubjectValuesGrade10 { get; set; }

        public List<string> EnrolledPerSubjectLabelGrade11 { get; set; }
        public List<int> EnrolledPerSubjectValuesGrade11 { get; set; }

        public List<string> EnrolledPerSubjectLabelGrade12 { get; set; }
        public List<int> EnrolledPerSubjectValuesGrade12 { get; set; }
    }
}
