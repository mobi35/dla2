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
        private readonly IRoomRepository roomRepo;
        private readonly ISubjectRepository subjectRepo;
        private readonly IStudentRepository studentRepo;
        private readonly IScheduleRepository scheduleRepo;
        private readonly ISectionRepository sectionRepo;
        private readonly ITeacherRepository teacherRepo;

        public ScheduleController(IRoomRepository roomRepo, ISubjectRepository subjectRepo, IStudentRepository studentRepo, IScheduleRepository scheduleRepo, ISectionRepository sectionRepo, ITeacherRepository teacherRepo)
        {
            this.roomRepo = roomRepo;
            this.subjectRepo = subjectRepo;
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

        public JsonResult GetSchedule(string username, int grade)
        {
            try { 
            List<SchedTeachersViewModel> schedTeachersVM = new List<SchedTeachersViewModel>();
            var student = studentRepo.FindStudent(a => a.LRN == username);
            var section = sectionRepo.FindSection(a => a.SectionID == student.SectionID);
            var schedule = scheduleRepo.GetAll().Where(a => a.Grade == grade && a.SectionName == section.SectionName && a.SectionNumber == section.SectionNumber).ToList();

            foreach (var s in schedule)
            {
                schedTeachersVM.Add(new SchedTeachersViewModel()
                {
                    Student = student,
                    Schedule = s,
                    Section = section,
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

            schedule.Areas = subjectRepo.FindSubject(a => a.SubjectName == schedule.SubjectName).Areas;
            var checkSubject = scheduleRepo.FindSchedule(a => a.Areas == schedule.Areas &&  a.SectionNumber == getSection.SectionNumber && a.Grade == schedule.Grade);

            schedule.SectionName = getSection.SectionName;
            schedule.SectionNumber = getSection.SectionNumber;

          

            if (checkSubject != null)
                return "subject_exist";


            if (schedule.EndTime <= schedule.StartTime)
                return "time_error";

            scheduleRepo.Create(schedule);

                return "";
        }

        public IActionResult DeleteSchedule(int id)
        {

            scheduleRepo.Delete(scheduleRepo.FindSchedule(a => a.ScheduleID == id));

            TeacherSectionViewModel teacherSectionVM = new TeacherSectionViewModel
            {
                Schedule = scheduleRepo.GetAll().ToList(),
                Section = sectionRepo.GetAll().ToList(),
                Teacher = teacherRepo.GetAll().Where(a => a.UserLevel == "Teacher").ToList()
            };
            return View("Index", teacherSectionVM);
        }

        public string UpdateTeachingTime(Schedule schedule)
        {

            var schedModel = scheduleRepo.FindSchedule(a => a.ScheduleID == schedule.ScheduleID);
            var getSection = sectionRepo.FindSection(a => a.SectionID == schedule.SectionNumber);

            var checkSchedTeacher = scheduleRepo.
          FindSchedule(a => a.ScheduleID != schedule.ScheduleID && a.StartTime >= schedule.StartTime && a.EndTime <= schedule.StartTime && a.TeacherID == schedModel.TeacherID ||
                       a.EndTime >= schedule.EndTime && a.EndTime <= schedule.EndTime && a.TeacherID == schedModel.TeacherID);

            if (checkSchedTeacher != null)
                return "time_discrepancy";


            var checkSched = scheduleRepo.
                FindSchedule(a => a.ScheduleID != schedule.ScheduleID && a.StartTime >= schedule.StartTime && a.EndTime <= schedule.StartTime && a.SectionNumber == getSection.SectionNumber ||
                            a.ScheduleID != schedule.ScheduleID && a.EndTime >= schedule.EndTime && a.EndTime <= schedule.EndTime && a.SectionNumber == getSection.SectionNumber);
            if (checkSched != null)
                return "time_discrepancy";
                

            if (schedule.EndTime <= schedule.StartTime)
                return "time_error";

            schedModel.StartTime = schedule.StartTime;
            schedModel.EndTime = schedule.EndTime;

            scheduleRepo.Update(schedModel);

            return "";

        }


    }
}