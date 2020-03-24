using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class UserController : Controller
    {
        private readonly IFeeRepository feeRepo;
        private readonly IBillingRepository billingRepo;
        private readonly ISubjectRepository subjectRepo;
        private readonly IGradeRepository gradeRepo;
        private readonly ITeacherRepository teacherRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IStudentRepository studentRepo;
        private readonly ISectionRepository sectionRepo;

        public UserController( IFeeRepository feeRepo, IBillingRepository billingRepo,  ISubjectRepository subjectRepo ,IGradeRepository gradeRepo, ITeacherRepository teacherRepo, IHostingEnvironment hostingEnvironment, IStudentRepository studentRepo, ISectionRepository sectionRepo)
        {
            this.feeRepo = feeRepo;
            this.billingRepo = billingRepo;
            this.subjectRepo = subjectRepo;
            this.gradeRepo = gradeRepo;
            this.teacherRepo = teacherRepo;
            this.hostingEnvironment = hostingEnvironment;
            this.studentRepo = studentRepo;
            this.sectionRepo = sectionRepo;
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



            if (teacherRepo.FindTeacher(a => a.Email == teacher.Email) != null)
                return "email_exist";

            if(teacher.UserLevel == "Teacher") { 
            foreach (var n in teacher.Skills.Split(",")) { 
            if(!subjectRepo.GetAll().Select(a => a.SubjectName).Contains(n))
                {
                    return "no_subject";
                }
             }
            }

            teacherRepo.Create(teacher);
            return "";
        }

        [HttpGet]
        public JsonResult GetSection(int grade)
        {

            List<Section> sortedSectionList = new List<Section>();

            var sections = sectionRepo.GetAll().Where(a => a.Grade == grade).ToList();

            var student = studentRepo.GetAll().Where(a => a.CurrentGrade == grade).GroupBy(a => a.SectionID).Select(x => new {

                SectionID = x.FirstOrDefault().SectionID,
                Count = x.Count()

            }).ToList();
         
            foreach (var s in student)
            {

                if (s.Count >= 40)
                    sections.Remove(sectionRepo.FindSection(a => a.SectionID == s.SectionID));

            }

         return Json(sections);
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

                GMailer.GmailUsername = "charlesbarney02@gmail.com";
                GMailer.GmailPassword = "Asakaboi35";
                GMailer mailer = new GMailer();
           
                mailer.ToEmail = student.EmailAddress;
                mailer.Subject = "DLA Registration";
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


            if(student.ModeOfPayment == "cash")
            {
               var fee = feeRepo.FindFee(a => a.PaymentName == "Tuition Fee" && a.GradeLevel == student.CurrentGrade);

                Billing billing = new Billing();
                billing.Payment = fee.PaymentPrice;
                billing.BilledDate = DateTime.Now;
                billing.Grade = student.CurrentGrade;
                billing.FeeID = fee.FeeID;
                billing.LRN = student.LRN;
                billing.Status = "Pending";
                billingRepo.Create(billing);
            }
            else if (student.ModeOfPayment == "two_payment")
            {
                var fee = feeRepo.FindFee(a => a.PaymentName == "Tuition Fee" && a.GradeLevel == student.CurrentGrade);
                
                var splitFee = (fee.PaymentPrice + (fee.PaymentPrice * 0.02f))/ 2;
                for(int i = 1; i <= 2; i++)
                {
                    Billing billing = new Billing();
                    billing.Payment = splitFee;
                    billing.BilledDate = DateTime.Now.AddMonths(i);
                    billing.Grade = student.CurrentGrade;
                    billing.LRN = student.LRN;
                    billing.FeeID = fee.FeeID;
                    billing.Status = "Pending";
                    billingRepo.Create(billing);
                }
               
            }
            else if (student.ModeOfPayment == "monthly")
            {
                var fee = feeRepo.FindFee(a => a.PaymentName == "Tuition Fee" && a.GradeLevel == student.CurrentGrade);
                var splitFee = (fee.PaymentPrice + (fee.PaymentPrice * 0.12f)) / 12;
                for (int i = 1; i <= 12; i++)
                {
                    Billing billing = new Billing();
                    billing.Payment = splitFee;
                    billing.BilledDate = DateTime.Now.AddMonths(i);
                    billing.Grade = student.CurrentGrade;
                    billing.LRN = student.LRN;
                    billing.FeeID = fee.FeeID;
                    billing.Status = "Pending";
                    billingRepo.Create(billing);
                }

            }
            else if (student.ModeOfPayment == "quarterly")
            {
                var fee = feeRepo.FindFee(a => a.PaymentName == "Tuition Fee" && a.GradeLevel == student.CurrentGrade);
                var splitFee = (fee.PaymentPrice + (fee.PaymentPrice * 0.12f)) / 12;
                for (int i = 1; i <= 4; i++)
                {
                    Billing billing = new Billing();
                    billing.Payment = splitFee;
                    billing.BilledDate = DateTime.Now.AddMonths(3*i); ;
                    billing.Grade = student.CurrentGrade;
                    billing.LRN = student.LRN;
                    billing.FeeID = fee.FeeID;
                    billing.Status = "Pending";
                    billingRepo.Create(billing);
                }

            }







            return "success";
        }

        public IActionResult DropOut(int id)
        {
            var student = studentRepo.FindStudent(a => a.StudentID == id);
            student.Status = "Dropped";
            studentRepo.Update(student);
            return View("Index");
        }

        public string AddSection(Student student)
        {

            var s = studentRepo.FindStudent(a => a.LRN == student.LRN);
            s.SectionID = student.SectionID;
            studentRepo.Update(s);

            return "";
        }

        public IActionResult Levelup(int id)
        {
            var stud = studentRepo.FindStudent(a => a.StudentID == id);
            stud.CurrentGrade++;
            studentRepo.Update(stud);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = "<script>alert('Successfully Levelup'); window.open('.. /User/Index','_self')</script>"
            };
       
        }

        [HttpGet]
        public JsonResult GetSectionInUser(string id)
        {
            var grade = studentRepo.FindStudent(a => a.LRN == id).CurrentGrade;
            var sections = sectionRepo.GetAll().Where(a => a.Grade == grade).ToList();
            var student = studentRepo.GetAll().Where(a => a.CurrentGrade == grade).GroupBy(a => a.SectionID).Select(x => new {

                SectionID = x.FirstOrDefault().SectionID,
                Count = x.Count()

            }).ToList();

            foreach (var s in student)
            {

                if (s.Count >= 40)
                    sections.Remove(sectionRepo.FindSection(a => a.SectionID == s.SectionID));

            }



            return Json(sections);

        }

        [HttpGet]
        public JsonResult GetSubject()
        {
            return Json(subjectRepo.GetAll().Select(a => a.SubjectName).ToList() );
        }

        public string GetEmployee(int id)
        {
            var employee = teacherRepo.FindTeacher(a => a.TeacherID == id);

            return ""+ employee.Skills;
        }

        public string UpdateTeacher(Teacher teacher)
        {
            var findTeacher = teacherRepo.FindTeacher(a => a.TeacherID == teacher.TeacherID);
            findTeacher.Skills = teacher.Skills;
            teacherRepo.Update(findTeacher);
            return "";
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