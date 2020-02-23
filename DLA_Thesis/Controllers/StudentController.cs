using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class StudentController : Controller
    {
        private readonly IGradeRepository gradeRepo;
        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;

        public StudentController(IGradeRepository gradeRepo,  ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo)
        {
            this.gradeRepo = gradeRepo;
            this.teacherRepo = teacherRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Settings() {

            return View();
            
            }
        [HttpGet]
        public JsonResult GetStudent(string username)
        {
            var user = studentRepo.FindStudent(a => a.LRN == username) ;

            return Json(user);
        }


        [HttpPost]
        public string UpdateAccount(Student student)
        {


            List<string> validation = new List<string>();

            var updateStudentModel = studentRepo.GetAll().AsQueryable().FirstOrDefault(a => a.LRN == student.LRN);

            if (student.FirstName == null)
                validation.Add("fname");

            if (student.MiddleName == null)
                validation.Add("mname");

            if (student.LastName == null)
                validation.Add("lname");

            if (student.Address == null)
                validation.Add("address");

            if (student.Barangay == null)
                validation.Add("barangay");

            if (student.City == null)
                validation.Add("city");


            if (student.Phonenumber == null)
                validation.Add("cpnumber");

            if (student.FatherFirstName == null)
                validation.Add("fatherfname");

            if (student.FatherLastName == null)
                validation.Add("fatherlname");


            if (student.MotherFirstName == null)
                validation.Add("motherfname");

            if (student.MotherLastName == null)
                validation.Add("motherlname");


            if (student.FatherOccupation != null)
                updateStudentModel.FatherOccupation = student.FatherOccupation;

            if (student.FatherNumber != null)
                updateStudentModel.FatherNumber = student.FatherNumber;

            if (student.MotherOccupation != null)
                updateStudentModel.MotherOccupation = student.MotherOccupation;

            if (student.MotherNumber != null)
                updateStudentModel.MotherNumber = student.MotherNumber;


            if (student.GuardianFirstName != null)
                updateStudentModel.GuardianFirstName = student.GuardianFirstName;

            if (student.GuardianLastName != null)
                updateStudentModel.GuardianLastName = student.GuardianLastName;

            if (student.GuardianOccupation != null)
                updateStudentModel.GuardianOccupation = student.GuardianOccupation;

            if (student.GuardianNumber != null)
                updateStudentModel.GuardianNumber = student.GuardianNumber;


            if (validation.Count != 0)
            {
                string validationList = string.Join(",", validation);
                return validationList;
            }


            updateStudentModel.FirstName = student.FirstName;
            updateStudentModel.MiddleName = student.MiddleName;
            updateStudentModel.LastName = student.LastName;
            updateStudentModel.Address = student.Address;
            updateStudentModel.Barangay = student.Barangay;
            updateStudentModel.City = student.City;
            updateStudentModel.Phonenumber = student.Phonenumber;
            updateStudentModel.FatherFirstName = student.FatherFirstName;
            updateStudentModel.FatherLastName = student.FatherLastName;
            updateStudentModel.MotherFirstName = student.MotherFirstName;
            updateStudentModel.MotherLastName = student.MotherLastName;

            studentRepo.Update(updateStudentModel);
            return "success";
        }

        public IActionResult Grades()
        {
        


            return View();
        }


        public JsonResult GetGrades(string username)
        {
            var student = studentRepo.FindStudent(a => a.LRN == username);
            var grades = gradeRepo.GetAll().Where(a => a.StudentLRN == username).ToList();
            return Json(grades);
        }


    }
}