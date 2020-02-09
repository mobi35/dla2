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

        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;

        public StudentController(ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo)
        {
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
        public JsonResult GetStudent(int username)
        {
            var user = studentRepo.FindStudent(a => a.LRN == username) ;

            return Json(user);
        }

        [HttpPost]
        public string Update(Student student)
        {

            var getStudent = studentRepo.FindStudent(a => a.LRN == student.LRN);

            getStudent.FirstName = student.FirstName;


            studentRepo.Update(getStudent);

            return "";
        }
    }
}