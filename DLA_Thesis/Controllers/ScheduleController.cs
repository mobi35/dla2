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
    public class ScheduleController : Controller
    {
        private readonly IStudentRepository studentRepo;
        private readonly IScheduleRepository scheduleRepo;
        private readonly ISectionRepository sectionRepo;
        private readonly ITeacherRepository teacherRepo;

        public ScheduleController(IStudentRepository studentRepo, IScheduleRepository scheduleRepo, ISectionRepository sectionRepo, ITeacherRepository teacherRepo)
        {
            this.studentRepo = studentRepo;
            this.scheduleRepo = scheduleRepo;
            this.sectionRepo = sectionRepo;
            this.teacherRepo = teacherRepo;
        }
        public IActionResult Index()
        {

            TeacherSectionViewModel teacherSectionVM = new TeacherSectionViewModel
            {
                Schedule = scheduleRepo.GetAll().ToList(),
                Section = sectionRepo.GetAll().ToList(),
                Teacher = teacherRepo.GetAll().Where(a => a.UserLevel == "Teacher").ToList()
            };

            return View(teacherSectionVM);
        }

        public IActionResult Student()
        {
          


            return View();
        }

        public JsonResult GetSchedule(string username)
        {
            try { 
            List<SchedTeachersViewModel> schedTeachersVM = new List<SchedTeachersViewModel>();
            var student = studentRepo.FindStudent(a => a.LRN == username);
            var section = sectionRepo.FindSection(a => a.SectionID == student.SectionID);
            var schedule = scheduleRepo.GetAll().Where(a => a.Grade == student.CurrentGrade && a.SectionName == section.SectionName && a.SectionNumber == section.SectionNumber).ToList();

            foreach (var s in schedule)
            {
                schedTeachersVM.Add(new SchedTeachersViewModel()
                {
                    Schedule = s,
                    Teacher = teacherRepo.FindTeacher(a => a.TeacherID == s.TeacherID)
                });

            }
                return Json(schedTeachersVM);
            }
            catch(Exception e)
            {
                return Json("error");
            }
          
        }

        [HttpPost]
        public string Create(Schedule schedule)
        {
           //GET SECTION FIRST
            var getSection = sectionRepo.FindSection(a => a.SectionID == schedule.SectionNumber);

            var checkSchedTeacher = scheduleRepo.
          FindSchedule(a => a.StartTime >= schedule.StartTime && a.EndTime <= schedule.StartTime && a.TeacherID == schedule.TeacherID ||
                       a.EndTime >= schedule.EndTime && a.EndTime <= schedule.EndTime && a.TeacherID == schedule.TeacherID);
          
            if (checkSchedTeacher != null)
                return "time_discrepancy";


            var checkSched = scheduleRepo.
                FindSchedule(a => a.StartTime >= schedule.StartTime && a.EndTime <= schedule.StartTime && a.SectionNumber == getSection.SectionNumber  ||
                             a.EndTime >= schedule.EndTime && a.EndTime <= schedule.EndTime && a.SectionNumber == getSection.SectionNumber );
            if (checkSched != null)
                return "time_discrepancy";

          


            var checkSubject = scheduleRepo.FindSchedule(a => a.SubjectName == schedule.SubjectName &&  a.SectionNumber == getSection.SectionNumber && a.Grade == schedule.Grade);

            schedule.SectionName = getSection.SectionName;
            schedule.SectionNumber = getSection.SectionNumber;
            if (checkSubject != null)
                return "subject_exist";


            if (schedule.EndTime <= schedule.StartTime)
                return "time_error";

            scheduleRepo.Create(schedule);

                return "";
        }


    }
}