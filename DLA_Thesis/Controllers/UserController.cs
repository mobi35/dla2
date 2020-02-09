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
            studentRepo.Create(student);

          
            return "";
        }

        
    }
}