using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class ReportController : Controller
    {
        private readonly IScheduleRepository scheduleRepo;
        private readonly IFeeRepository feeRepo;
        private readonly IBillingRepository billingRepo;
        private readonly ISubjectRepository subjectRepo;
        private readonly IGradeRepository gradeRepo;
        private readonly ITeacherRepository teacherRepo;
        private readonly IStudentRepository studentRepo;
        private readonly ISectionRepository sectionRepo;

        public ReportController(IScheduleRepository scheduleRepo, IFeeRepository feeRepo, IBillingRepository billingRepo, ISubjectRepository subjectRepo, IGradeRepository gradeRepo, ITeacherRepository teacherRepo,  IStudentRepository studentRepo, ISectionRepository sectionRepo)
        {
            this.scheduleRepo = scheduleRepo;
            this.feeRepo = feeRepo;
            this.billingRepo = billingRepo;
            this.subjectRepo = subjectRepo;
            this.gradeRepo = gradeRepo;
            this.teacherRepo = teacherRepo;
            this.studentRepo = studentRepo;
            this.sectionRepo = sectionRepo;
        }


         public string GetReport(string type)
        {
            string html = "";
            if(type == "master_student")
            {
                html += "<table class='table' id='reportDatatable'>";
                html += "<thead><tr>";
                    html += "<th>LRN</th>";
                    html += "<th>Full Name</th>";
                    html += "<th>Grade / Sec</th>";
                html += "</tr></thead>";

                html += "<tbody>";

                foreach (var m in studentRepo.GetAll())
                {

                    html += "<tr> <td> "+m.LRN+ " </td>";
                    html += "<td> " + m.FirstName + " " + m.MiddleName + " " + m.LastName + " </td>";
                    if (sectionRepo.FindSection(a => a.SectionID == m.SectionID) != null)
                        html += "<td>  " + m.CurrentGrade + " / " + sectionRepo.FindSection(a => a.SectionID == m.SectionID).SectionNumber  + "</td></tr>";
                    else
                    {
                        html += "<td>" + m.CurrentGrade+ "</td> </tr>";
                    }
                }
                html += "</tbody>";
                html += "</table>";

                return html;
            }else if (type == "subject_per_grade")
            {
                html += "<table class='table' id='reportDatatable'>";
                html += "<thead><tr>";
                html += "<th>Grade</th>";
                html += "<th>Area</th>";
                html += "<th>Subject Code</th>";
                html += "<th>Subject Name</th>";
                html += "</tr></thead>";

                html += "<tbody>";

                foreach (var m in subjectRepo.GetAll().OrderBy(a => a.Grade).ToList() )
                {

                    html += "<tr> <td> " + m.Grade + " </td>";
                    html += "<td> " + m.Areas + " </td>";
                    html += "<td>" + m.SubjectCode + "</td>";
                    html += "<td>" + m.SubjectName + "</td> </tr>";
                }
                html += "</tbody>";
                html += "</table>";

                return html;
            }
            else if (type == "subject_per_section")
            {
                html += "<table class='table' id='reportDatatable'>";
                html += "<thead><tr>";
                html += "<th>Grade / Section</th>";
                html += "<th>Subject Name</th>";
                html += "<th>Schedule</th>";
                html += "</tr></thead>";

                html += "<tbody>";

                foreach (var m in scheduleRepo.GetAll().OrderBy(a => a.Grade).ToList())
                {
                    html += "<tr> <td> " + m.Grade + " / " + m.SectionNumber + " - " + m.SectionName + " </td>";
                    html += "<td> " + m.SubjectName + " </td>";
                    html += "<td>" + m.StartTime + " - " + m.EndTime + "</td> </tr>";
                }
                html += "</tbody>";
                html += "</table>";

                return html;
            }
            else if (type == "subject_for_teacher")
            {
                html += "<table class='table' id='reportDatatable'>";
                html += "<thead><tr>";
                html += "<th>Grade / Section</th>";
                html += "<th>Teacher</th>";
                html += "<th>Subject Name</th>";
                html += "<th>Schedule</th>";
                html += "</tr></thead>";
                html += "<tbody>";

                foreach (var m in scheduleRepo.GetAll().OrderBy(a => a.Grade).ToList())
                {
                    html += "<tr> <td> " + m.Grade + " / " + m.SectionNumber + " - " + m.SectionName + " </td>";
                    html += "<td> " + teacherRepo.FindTeacher(a => a.TeacherID == m.TeacherID).FirstName + " " + teacherRepo.FindTeacher(a => a.TeacherID == m.TeacherID).MiddleName + " " + teacherRepo.FindTeacher(a => a.TeacherID == m.TeacherID).LastName + " </td>";
                    html += "<td> " + m.SubjectName + " </td>";
                    html += "<td>" + m.StartTime + " - " + m.EndTime + "</td> </tr>";
                }
                html += "</tbody>";
                html += "</table>";

                return html;
            }

            return "";
        }

        public IActionResult Index()
        {
            return View();
        }

        
    }
}