using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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

        public JsonResult ExecuteLogin(string userType, string userName, string password)
        {

            if(userType == "student")
            {
             
                var user = studentRepo.FindStudent(a => a.LRN == userName && a.Password == password);
                if (user != null) {
                 
                    return Json(user);
                }
                else
                    return Json("Error");
            }
            else
            {
                var user = teacherRepo.FindTeacher(a => a.Email == userName && a.Password == password);
                if (user != null)
                {
                    return Json(user);
                }
                else
                    return Json("Error");

            }


         


        }

        public string Recover(string email)
        {

            var student = studentRepo.FindStudent(a => a.EmailAddress == email);
            if (student == null)
                return "email_not_found";


            try
            {
                // Output Registered to the Register Page if the data is inserted properly.
                //This block of code is for sending mail

                GMailer.GmailUsername = "charlesbarney02@gmail.com";
                GMailer.GmailPassword = "Asakaboi35";
                GMailer mailer = new GMailer();
                // passing the email address of the newly registered user
                mailer.ToEmail = student.EmailAddress;
                // Mail Subject
                mailer.Subject = "DLA Registration";
                //Mail Body
                mailer.Body += "Hi " + student.FirstName + " " + student.LastName;
                mailer.Body += "<br> Please click here to recover your account";
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception e)
            {

                return ("");

            }



            return "";

        }






  



    }
}