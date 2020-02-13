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
        public IActionResult Index()
        {

            TeacherSectionViewModel teacherSectionVM = new TeacherSectionViewModel
            {
                Section = sectionRepo.GetAll().ToList(),
                Teacher = teacherRepo.GetAll().Where(a => a.UserLevel == "Teacher").ToList()
            };

            return View(teacherSectionVM) ;
        }
        [HttpPost]
        public string Create(Section section)
        {
            sectionRepo.Create(section);

            return "";
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