using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLA_Thesis.Models;
using DLA_Thesis.Data.Model.Interface;

namespace DLA_Thesis.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScheduleRepository schedRepo;
        private readonly IFeeRepository feeRepo;
        private readonly IBillingRepository billingRepo;
        private readonly ISubjectRepository subjectRepo;
        private readonly IGradeRepository gradeRepo;
        private readonly ITeacherRepository teacherRepo;
        private readonly IStudentRepository studentRepo;
        private readonly ISectionRepository sectionRepo;

        public HomeController(IScheduleRepository schedRepo, IFeeRepository feeRepo, IBillingRepository billingRepo, ISubjectRepository subjectRepo, IGradeRepository gradeRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo, ISectionRepository sectionRepo)
        {
            this.schedRepo = schedRepo;
            this.feeRepo = feeRepo;
            this.billingRepo = billingRepo;
            this.subjectRepo = subjectRepo;
            this.gradeRepo = gradeRepo;
            this.teacherRepo = teacherRepo;
            this.studentRepo = studentRepo;
            this.sectionRepo = sectionRepo;
        }


        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Admin()
        {
            var dash = new Dashboard();

            dash.TotalPayments = billingRepo.GetAll().Where(a => a.Status == "Paid").Select(a => a.Payment).Sum();
            dash.NumberOfStudent = studentRepo.GetAll().Count();
            dash.NumberOfTeacher = teacherRepo.GetAll().Where(a => a.UserLevel == "Teacher").Count();
            dash.NumberOfEmployees = teacherRepo.GetAll().Where(a => a.UserLevel != "Teacher").Count();

             List<float> payments = new List<float>();

            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 1).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 2).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 3).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 4).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 5).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 6).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 7).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 8).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 9).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 10).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 12).Select(a => a.Payment).Sum());
            payments.Add(billingRepo.GetAll().Where(a => a.Status == "Paid" && a.BilledDate.Month == 12).Select(a => a.Payment).Sum());
            dash.PaymentsChartValues = payments;



            //GRADE 7 CHART
          
            var subject7Values = new List<int>();
            var subjectGrade7 = subjectRepo.GetAll().Where(a => a.Grade == 7).Select(a => a.SubjectName).ToList();
            var studentOnGrade7 = studentRepo.GetAll().Where(a => a.CurrentGrade == 7).ToList();
            if (subjectGrade7.Count != 0)
            {
               
                foreach (var s in subjectGrade7)
                {
                    int grade7Count = 0;
                    foreach (var student in studentOnGrade7)
                    {
                        if(student.SectionID != 0) { 
                            if ( schedRepo.FindSchedule(a => a.SubjectName == s &&  a.SectionName ==  sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName  ) != null )
                            {
                                grade7Count++;
                            }
                        }

                    }
                    subject7Values.Add(grade7Count);
                }
            }

            var scheduleGrade7 = schedRepo.GetAll().Where(a => a.Grade == 7).ToList();

            dash.EnrolledPerSubjectLabelGrade7 = subjectGrade7;
            dash.EnrolledPerSubjectValuesGrade7 = subject7Values;



            //GRADE 8 CHART

            var subject8Values = new List<int>();
            var subjectGrade8 = subjectRepo.GetAll().Where(a => a.Grade == 8).Select(a => a.SubjectName).ToList();
            var studentOnGrade8 = studentRepo.GetAll().Where(a => a.CurrentGrade == 8).ToList();
            if (subjectGrade8.Count != 0)
            {

                foreach (var s in subjectGrade8)
                {
                    int grade8Count = 0;
                    foreach (var student in studentOnGrade8)
                    {
                        if (student.SectionID != 0)
                        {
                            if (schedRepo.FindSchedule(a => a.SubjectName == s && a.SectionName == sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName) != null)
                            {
                                grade8Count++;
                            }
                        }

                    }
                    subject8Values.Add(grade8Count);
                }
            }



            dash.EnrolledPerSubjectLabelGrade8 = subjectGrade8;
            dash.EnrolledPerSubjectValuesGrade8 = subject8Values;



            //GRADE 9 CHART

            var subject9Values = new List<int>();
            var subjectGrade9 = subjectRepo.GetAll().Where(a => a.Grade == 9).Select(a => a.SubjectName).ToList();
            var studentOnGrade9 = studentRepo.GetAll().Where(a => a.CurrentGrade == 9).ToList();
            if (subjectGrade9.Count != 0)
            {

                foreach (var s in subjectGrade9)
                {
                    int grade9Count = 0;
                    foreach (var student in studentOnGrade9)
                    {
                        if (student.SectionID != 0)
                        {
                            if (schedRepo.FindSchedule(a => a.SubjectName == s && a.SectionName == sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName) != null)
                            {
                                grade9Count++;
                            }
                        }

                    }
                    subject8Values.Add(grade9Count);
                }
            }


            dash.EnrolledPerSubjectLabelGrade9 = subjectGrade9;
            dash.EnrolledPerSubjectValuesGrade9 = subject9Values;

            //GRADE 10 CHART

            var subject10Values = new List<int>();
            var subjectGrade10 = subjectRepo.GetAll().Where(a => a.Grade == 10).Select(a => a.SubjectName).ToList();
            var studentOnGrade10 = studentRepo.GetAll().Where(a => a.CurrentGrade == 10).ToList();
            if (subjectGrade10.Count != 0)
            {

                foreach (var s in subjectGrade10)
                {
                    int grade10Count = 0;
                    foreach (var student in studentOnGrade10)
                    {
                        if (student.SectionID != 0)
                        {
                            if (schedRepo.FindSchedule(a => a.SubjectName == s && a.SectionName == sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName) != null)
                            {
                                grade10Count++;
                            }
                        }

                    }
                    subject8Values.Add(grade10Count);
                }
            }


            dash.EnrolledPerSubjectLabelGrade10 = subjectGrade10;
            dash.EnrolledPerSubjectValuesGrade10 = subject10Values;


            //GRADE 11 CHART

            var subject11Values = new List<int>();
            var subjectGrade11 = subjectRepo.GetAll().Where(a => a.Grade == 11).Select(a => a.SubjectName).ToList();
            var studentOnGrade11 = studentRepo.GetAll().Where(a => a.CurrentGrade == 11).ToList();
            if (subjectGrade11.Count != 0)
            {

                foreach (var s in subjectGrade11)
                {
                    int grade11Count = 0;
                    foreach (var student in studentOnGrade11)
                    {
                        if (student.SectionID != 0)
                        {
                            if (schedRepo.FindSchedule(a => a.SubjectName == s && a.SectionName == sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName) != null)
                            {
                                grade11Count++;
                            }
                        }

                    }
                    subject8Values.Add(grade11Count);
                }
            }


            dash.EnrolledPerSubjectLabelGrade11 = subjectGrade11;
            dash.EnrolledPerSubjectValuesGrade11 = subject11Values;



            //GRADE 12 CHART

            var subject12Values = new List<int>();
            var subjectGrade12 = subjectRepo.GetAll().Where(a => a.Grade == 12).Select(a => a.SubjectName).ToList();
            var studentOnGrade12 = studentRepo.GetAll().Where(a => a.CurrentGrade == 12).ToList();
            if (subjectGrade12.Count != 0)
            {

                foreach (var s in subjectGrade12)
                {
                    int grade12Count = 0;
                    foreach (var student in studentOnGrade12)
                    {
                        if (student.SectionID != 0)
                        {
                            if (schedRepo.FindSchedule(a => a.SubjectName == s && a.SectionName == sectionRepo.FindSection(z => z.SectionID == student.SectionID).SectionName) != null)
                            {
                                grade12Count++;
                            }
                        }

                    }
                    subject8Values.Add(grade12Count);
                }
            }


            dash.EnrolledPerSubjectLabelGrade12 = subjectGrade12;
            dash.EnrolledPerSubjectValuesGrade12 = subject12Values;




            return View(dash);
        }

        public IActionResult Client()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Enroll()
        {
            return View();
        }

    }
}
