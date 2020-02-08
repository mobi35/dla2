using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class LoginController : Controller
    {
        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;

        public LoginController(ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo)
        {
            this.teacherRepo = teacherRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
          
            return View(studentRepo.GetAll().OrderByDescending(a => a.StudentID).ToList());
        }

        public string ExecuteLogin(string userType, string userName, string password)
        {

            if(userType == "student")
            {
                int numberLRN = Int32.Parse(userName);
                var user = studentRepo.FindStudent(a => a.LRN == numberLRN && a.Password == password);
                if (user != null)
                    return "";
                else
                    return "error";

            }else
            {
                var user = teacherRepo.FindTeacher(a => a.TeacherCode == userName && a.Password == password);
                if (user != null)
                    return "";
                else
                    return "error";

            }


         


        }





  
    }
}