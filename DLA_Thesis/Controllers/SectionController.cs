using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using DLA_Thesis.Models;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class SectionController : Controller
    {
        private readonly ISectionRepository sectionRepo;
        private readonly ITeacherRepository teacherRepo;

        public SectionController(ISectionRepository sectionRepo, ITeacherRepository teacherRepo)
        {
            this.sectionRepo = sectionRepo;
            this.teacherRepo = teacherRepo;
        }

        public TeacherSectionViewModel TeacherVMList()
        {
            List<Teacher> teachers = new List<Teacher>();
            var listOfTeacher = teacherRepo.GetAll().Where(a => a.UserLevel == "Teacher").ToList();
            var listOfSection = sectionRepo.GetAll().Select(a => a.TeacherID).ToList();
            foreach (var t in listOfTeacher)
            {
                if (!listOfSection.Contains(t.TeacherID))
                    teachers.Add(t);
            }

            TeacherSectionViewModel teacherSectionVM = new TeacherSectionViewModel
            {
                Section = sectionRepo.GetAll().ToList(),
                Teacher = teachers
            };
            return teacherSectionVM;
        }

        public IActionResult Index()
        {

            return View(TeacherVMList()) ;
        }
        [HttpPost]
        public string Create(Section section)
        {
            var checkSection = sectionRepo.FindSection(a => a.SectionNumber == section.SectionNumber && a.Grade == section.Grade);
            if (checkSection != null)
                return "existed";

            var checkTeacher = sectionRepo.FindSection(a => a.TeacherID == section.TeacherID);
            if (checkSection != null || section.TeacherID == 0  )
                return "existingteacher";

            sectionRepo.Create(section);

            return "";
        }
        [HttpPost]
        public JsonResult GetSubject(Teacher teacher)
        {

            var t = teacherRepo.FindTeacher(a => a.TeacherID == teacher.TeacherID);
           var subjectString =  t.Skills.Split(",");
            
        

            return Json(subjectString);
        }

        public IActionResult RemoveAdvisory(int id)
        {
            var t = teacherRepo.FindTeacher(a => a.TeacherID == id);
            var section = sectionRepo.FindSection(a => a.TeacherID == t.TeacherID);
            section.TeacherID = 0;
            sectionRepo.Update(section);
            return View("Index", TeacherVMList());
        }

        public string UpdateTeacher(Section section)
        {
            var sec = sectionRepo.FindSection(a => a.SectionID == section.SectionID);
            sec.TeacherID = section.TeacherID;
            sectionRepo.Update(sec);

            return "";

        }
    }
}