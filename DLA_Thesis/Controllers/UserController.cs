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
    }
}