using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using DLA_Thesis.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;

namespace DLA_Thesis.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ISubjectRepository subjectRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IScheduleRepository scheduleRepo;
        private readonly IGradeRepository gradeRepo;
        private readonly ITeacherRepository teacherRepo;
        private readonly IStudentRepository studentRepo;
        private readonly ISectionRepository sectionRepo;

        public TeacherController(ISubjectRepository subjectRepo, IHostingEnvironment hostingEnvironment, IScheduleRepository scheduleRepo,IGradeRepository gradeRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo, ISectionRepository sectionRepo)
        {
            this.subjectRepo = subjectRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.scheduleRepo = scheduleRepo;
            this.gradeRepo = gradeRepo;
            this.teacherRepo = teacherRepo;
         
            this.studentRepo = studentRepo;
            this.sectionRepo = sectionRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

 
        public IActionResult AssignedSection(string email)
        {
            var teacher = teacherRepo.FindTeacher(a => a.Email == email);

           var schedule = scheduleRepo.GetAll().Where(a => a.TeacherID == teacher.TeacherID).ToList();
            
            return View(schedule);
        }

        [HttpPost]
        public async Task<string> UploadExcelGrades(GradeRegistrationFileStructure grades)
        {
            if (grades.ExcelFile == null || grades.ExcelFile.Length == 0)
                return "no_file";

            string fileExtension = Path.GetExtension(grades.ExcelFile.FileName);

            if (fileExtension == ".xls" || fileExtension == ".xlsx")
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "");
                var fileName = grades.ExcelFile.FileName;
                var filePath = Path.Combine(uploadsFolder, fileName);
                var fileLocation = new FileInfo(filePath);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await grades.ExcelFile.CopyToAsync(fileStream);
                }
                var DataList = new List<ExcelGrades>();
                var code = Guid.NewGuid().ToString("N");
                ExcelPackage package = new ExcelPackage(fileLocation);
                
                    ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                    int totalRows = workSheet.Dimension.Rows;

                    for (int i = 1; i <= totalRows; i++)
                    {
                    if (workSheet.Cells[i, 1].Value.ToString().Any(char.IsLetter) || workSheet.Cells[i, 2].Value.ToString().Any(char.IsLetter))
                        continue;
                        DataList.Add(new ExcelGrades
                        {
                            LRN = workSheet.Cells[i, 1].Value.ToString(),
                            Grade =workSheet.Cells[i, 2].Value.ToString()
                        });
                    }
               
                foreach (var data in DataList)
                {
                   
                    Grade gradeModel = new Grade();
                    
                    if( data.LRN.ToCharArray().Any(char.IsDigit) && MathF.Floor( float.Parse( data.Grade.ToString())).ToString().ToCharArray().Any(char.IsDigit)) { 
                      
                    gradeModel.StudentLRN = data.LRN;
                   gradeModel.SubjectGrade = float.Parse( data.Grade.ToString() );
                    gradeModel.Grading = grades.Grading;
                    var getUser = studentRepo.FindStudent(a => a.LRN == data.LRN);
                    gradeModel.GradeLevel = getUser.CurrentGrade;
                    gradeModel.SectionID = getUser.SectionID;
                    var getSchedule = scheduleRepo.FindSchedule(a => a.ScheduleID == grades.ScheduleID);
                    var getSubject = subjectRepo.FindSubject(a => a.SubjectName == getSchedule.SubjectName);
                    gradeModel.SubjectCode = getSubject.SubjectCode;
                    gradeModel.TeacherEmail = grades.Teacher;
                        gradeModel.DateAdded = DateTime.Now;
                        //CHECK IF THE GRADES IS EXISTING
                        var checkGrade = gradeRepo.FindGrade(a => a.StudentLRN == data.LRN && a.GradeLevel == getUser.CurrentGrade
                         && a.SectionID == getUser.SectionID && a.Grading == grades.Grading);
                        if (checkGrade != null )
                        {
                            gradeRepo.Delete(checkGrade);
                        }
                        gradeRepo.Create(gradeModel);


                    }

                }

            }
            return "";
        }





        [HttpGet]
        public JsonResult GetSection(int id)  {

            var sched = scheduleRepo.FindSchedule(a => a.ScheduleID == id);

            var getSection = sectionRepo.FindSection(a => a.SectionName == sched.SectionName && a.SectionNumber == sched.SectionNumber);

            var students = studentRepo.GetAll().Where(a => a.SectionID == getSection.SectionID).ToList();
            var grades = gradeRepo.GetAll();

            List<StudentGrade> studentGrade = new List<StudentGrade>();

            foreach(var s in students)
            {
                studentGrade.Add(new StudentGrade { 
                Student = s,
                FirstGrading = gradeRepo.GetAll().Where(a => a.GradeLevel == s.CurrentGrade && a.SectionID == getSection.SectionID && a.Grading == 1).Select(a => a.SubjectGrade).DefaultIfEmpty(0).First(),
                SecondGrading = gradeRepo.GetAll().Where(a => a.GradeLevel == s.CurrentGrade && a.SectionID == getSection.SectionID && a.Grading == 2).Select(a => a.SubjectGrade).DefaultIfEmpty(0).First(),
                ThirdGrading = gradeRepo.GetAll().Where(a => a.GradeLevel == s.CurrentGrade && a.SectionID == getSection.SectionID && a.Grading == 3).Select(a => a.SubjectGrade).DefaultIfEmpty(0).First(),
                FourthGrading = gradeRepo.GetAll().Where(a => a.GradeLevel == s.CurrentGrade && a.SectionID == getSection.SectionID && a.Grading == 4).Select(a => a.SubjectGrade).DefaultIfEmpty(0).First()
                });
            }

            return Json(studentGrade);
        }

        public IActionResult Teacher()
        {

            return View();
        }
    }
}