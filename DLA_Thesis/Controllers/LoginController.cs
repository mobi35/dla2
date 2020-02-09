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

        public IActionResult ExecuteLogin(string userType, string userName, string password)
        {

            if(userType == "student")
            {
                int numberLRN = Int32.Parse(userName);
                var user = studentRepo.FindStudent(a => a.LRN == numberLRN && a.Password == password);
                if (user != null) {
                    return Content(user.LRN.ToString());

                }
                else
                    return Content("Error");

            }
            else
            {
                var user = teacherRepo.FindTeacher(a => a.Email == userName && a.Password == password);
                if (user != null)
                {
                    return Content(user.Email);
                }
                else
                    return Content("Error");

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






        public class GMailer
        {
            public static string GmailUsername { get; set; }
            public static string GmailPassword { get; set; }
            public static string GmailHost { get; set; }
            public static int GmailPort { get; set; }
            public static bool GmailSSL { get; set; }

            public string ToEmail { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }
            public bool IsHtml { get; set; }

            static GMailer()
            {
                GmailHost = "smtp.gmail.com";
                GmailPort = 587; // Gmail can use ports 25, 465 & 587; but must be 25 for medium trust environment.
                GmailSSL = true;
            }

            public void Send()
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = GmailHost;
                smtp.Port = GmailPort;
                smtp.EnableSsl = GmailSSL;
                smtp.TargetName = "STARTTLS/smtp.gmail.com";

                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(GmailUsername, GmailPassword);

                using (var message = new MailMessage(GmailUsername, ToEmail))
                {
                    message.Subject = Subject;
                    message.Body = Body;
                    message.IsBodyHtml = IsHtml;
                    smtp.Send(message);
                }
            }


        }





    }
}