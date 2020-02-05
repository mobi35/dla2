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
        private readonly ISubjectRepository subjectRepo;

        public SubjectController(ISubjectRepository subjectRepo)
        {
            this.subjectRepo = subjectRepo;
        }

        public IActionResult Index()
        {

            return View(subjectRepo.GetAll().OrderByDescending(a => a.SubjectID).ToList());
        }

        public string CreateSubject(Subject subject)
        {
            subjectRepo.Create(subject);

            return "";
        }







    }
}
