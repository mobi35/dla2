using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DLA_Thesis.Models;
using DLA_Thesis.Data.Model.Interface;
using DLA_Thesis.Data.Model;

namespace DLA_Thesis.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectAreaRepository subjectAreaRepo;
        private readonly ISubjectRepository subjectRepo;

        public SubjectController(ISubjectAreaRepository subjectAreaRepo, ISubjectRepository subjectRepo)
        {
            this.subjectAreaRepo = subjectAreaRepo;
            this.subjectRepo = subjectRepo;
        }

        public IActionResult Index()
        {

            return View(subjectRepo.GetAll().OrderByDescending(a => a.SubjectID).ToList());
        }

        

        public string CreateSubject(Subject subject)
        {

          

            var checkSubject = subjectRepo.FindSubject(a =>  a.SubjectName == subject.SubjectName || a.SubjectCode == subject.SubjectCode);

            if (checkSubject != null)
            {
                return "existing_subject";
            }
            subjectRepo.Create(subject);
            return "";
        }
        
      

        public JsonResult GetAllArea()
        {
            return Json(subjectAreaRepo.GetAll().ToList());
        }
        [HttpPost]
        public string CreateArea(string areaName)
        {

            var checkSubjectArea = subjectAreaRepo.FindSubjectArea(a => a.AreaName == areaName);
            if(checkSubjectArea != null)
            {
                return "existing_area";
            }

            SubjectArea subArea = new SubjectArea();
            subArea.AreaName = areaName;

            subjectAreaRepo.Create(subArea);
            return "";
        }

        public string UpdateArea(int editAreaID, string editAreaName)
        {

            var checkSubject = subjectAreaRepo.FindSubjectArea(a => a.SubjectAreaID != editAreaID && a.AreaName == editAreaName);

            if (checkSubject != null)
            {
                return "existing_area";
            }

            var findAndEdit = subjectAreaRepo.FindSubjectArea(a => a.SubjectAreaID == editAreaID);
            findAndEdit.AreaName = editAreaName;
            subjectAreaRepo.Update(findAndEdit);
           
            return "";
        }







    }
}
