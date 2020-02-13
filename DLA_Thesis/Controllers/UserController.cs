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
    public class UserController : Controller
    {
        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;

        public UserController(ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo)
        {
            this.teacherRepo = teacherRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
          
            return View(studentRepo.GetAll().OrderByDescending(a => a.StudentID).ToList());
        }

        public IActionResult Teacher()
        {
            return View(teacherRepo.GetAll().OrderByDescending(a => a.TeacherID).ToList());
        }


        public string CreateStudent(Student student)
        {

            if (student.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                student.ImageName = uniqueName;
            }

            if (studentRepo.FindStudent(a => a.LRN == student.LRN) != null)
                return "LRN_exist";
            else if (teacherRepo.FindTeacher(a => a.Email == student.EmailAddress) != null)
                return "email_exist";


            studentRepo.Create(student);
            return "";
        }


        public string CreateTeacher(Teacher teacher)
        {

            if (teacher.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Teacher");
                var uniqueName = Guid.NewGuid().ToString() + "_" + teacher.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                teacher.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                teacher.ImageName = uniqueName;
            }

            teacherRepo.Create(teacher);
            return "";
        }


        public IActionResult AcceptStudentEnrollment(int id)
        {
            
          var student =  studentRepo.FindStudent(a => a.StudentID == id);
            student.Status = "Active";
            studentRepo.Update(student);
            return RedirectToAction("Index", "User");
        }

        public IActionResult DeclineStudentEnrollment(int id)
        {
           
            var student = studentRepo.FindStudent(a => a.StudentID == id);
            student.Status = "Declined";
            studentRepo.Update(student);
            return RedirectToAction("Index","User");
        }

        public string StudentEnroll(Student student)
        {

            if (student.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                student.ImageName = uniqueName;
            }

            if (student.BirthCertificate != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.BirthCertificate.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.BirthCertificate.CopyTo(new FileStream(filePath, FileMode.Create));
                student.BirthCertificateName = uniqueName;
            }

            if (student.Form137 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.Form137.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.Form137.CopyTo(new FileStream(filePath, FileMode.Create));
                student.Form137Name = uniqueName;
            }

            if (student.Form138 != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.Form138.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.Form138.CopyTo(new FileStream(filePath, FileMode.Create));
                student.Form138Name = uniqueName;
            }

            if (student.GoodMoral != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "Student");
                var uniqueName = Guid.NewGuid().ToString() + "_" + student.GoodMoral.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueName);
                student.GoodMoral.CopyTo(new FileStream(filePath, FileMode.Create));
                student.GoodMoralName = uniqueName;
            }
            student.Password = Guid.NewGuid().ToString();
          

            List<string> validation = new List<string>();


            var checkLRN = studentRepo.GetAll().Where(a => a.LRN == student.LRN).ToList();

            if (student.LRN == null || student.LRN.ToString().Length != 12 )
                validation.Add("lrn_error");
            else if (!student.LRN.ToString().Any(char.IsDigit))
                validation.Add("lrn_number_only");
            else if (checkLRN.Count > 0)
                validation.Add("lrn_exist");

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


            if (student.Phonenumber== null)
                validation.Add("cpnumber");

            if (student.FatherFirstName == null)
                validation.Add("fatherfname");

            if (student.FatherLastName == null)
                validation.Add("fatherlname");


            if (student.MotherFirstName == null)
                validation.Add("motherfname");

            if (student.MotherLastName == null)
                validation.Add("motherlname");

            var checkEmail = studentRepo.GetAll().Where(a => a.EmailAddress == student.EmailAddress).ToList();
            if (checkEmail.Count > 0)
                validation.Add("email_exist");
            else if (student.EmailAddress == null)
                validation.Add("email");
            else  if (!IsValidEmail(student.EmailAddress))
                   validation.Add("invalid_email");

                

   


            if (validation.Count != 0) { 
                string validationList = string.Join(",", validation);
                return validationList;
            }

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
                mailer.Body += "<br> Here's your username : " + student.LRN;
                mailer.Body += "<br> Here's your password : " + student.Password;

                mailer.Body += "<br> You can change your password anytime in your settings. ";
                mailer.IsHtml = true;
                mailer.Send();
            }
            catch (Exception e)
            {


            }

            studentRepo.Create(student);
            return "success";
        }




        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public IActionResult ChangePassword()
        {

            return View();
        }

 
        public string ChangePasswordExecute(string lrn, string oldpass, string newpass)
        {

            List<string> validation = new List<string>();

            var studentModel = studentRepo.GetAll().AsQueryable().FirstOrDefault(a => a.LRN == lrn);


            if (studentModel.Password != oldpass)
                validation.Add("wrong_old_password");

            if (validation.Count > 0)
            {
                string validationList = string.Join(",", validation);
                return validationList;
            }

            studentModel.Password = newpass;
            studentRepo.Update(studentModel);
            return "success";
        }





    }
}