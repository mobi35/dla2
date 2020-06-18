﻿using System;
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
        private readonly ISubjectRepository subjectRepo;
        private readonly IScheduleRepository scheduleRepo;
        private readonly IRoomRepository roomRepo;
        private readonly ISectionRepository sectionRepo;
        private readonly ITeacherRepository teacherRepo;

        public SectionController(ISubjectRepository subjectRepo, IScheduleRepository scheduleRepo, IRoomRepository roomRepo,  ISectionRepository sectionRepo, ITeacherRepository teacherRepo)
        {
            this.subjectRepo = subjectRepo;
            this.scheduleRepo = scheduleRepo;
            this.roomRepo = roomRepo;
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

            var roomRep = roomRepo.FindRoom(a => a.RoomNumber == section.RoomNumber);
            roomRep.SectionID = sectionRepo.GetAll().LastOrDefault().SectionID;
            roomRepo.Update(roomRep);

            return "";
        }
        [HttpPost]
        public JsonResult GetSubject(Teacher teacher)
        {
            if(teacher.Courses == null)
            {
                teacher.Courses = "0";
            }
            var t = teacherRepo.FindTeacher(a => a.TeacherID == teacher.TeacherID);

            var level = int.Parse(teacher.Courses);
            var subject = subjectRepo.GetAll().Where(a => a.Grade == level).ToList();

            var newSubject = new List<string>();
            foreach (var s in t.Skills.Split(","))
            {
                if ( subject.Select(a => a.SubjectName).Contains(s) )
                {
                    newSubject.Add(s);
                }
            }

           var subjectString =  t.Skills.Split(",");

            return Json(newSubject);
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

        public JsonResult ViewSched(int id)
        {
            var section = sectionRepo.FindSection(a => a.SectionID == id);
         
            var sched = scheduleRepo.GetAll().Where(a => a.SectionName == section.SectionName).ToList();
            var teacherSched = new List<SchedTeachersViewModel>();
            foreach(var s in sched)
            {
                teacherSched.Add(new SchedTeachersViewModel
                {
                    Schedule = s,
                    Teacher = teacherRepo.FindTeacher(a => a.TeacherID == s.TeacherID)
                });
            }
            
            return Json(teacherSched);
        }
    }
}