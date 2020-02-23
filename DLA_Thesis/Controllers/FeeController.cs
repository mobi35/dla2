using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DLA_Thesis.Controllers
{
    public class FeeController : Controller
    {
        private readonly IFeeRepository feeRepo;
        private readonly ITeacherRepository teacherRepo;

        private readonly IStudentRepository studentRepo;

        public FeeController(IFeeRepository feeRepo, ITeacherRepository teacherRepo, IStudentRepository studentRepo)
        {
            this.feeRepo = feeRepo;
            this.teacherRepo = teacherRepo;
            this.studentRepo = studentRepo;
        }
        public IActionResult Index()
        {
            return View(feeRepo.GetAll());
        }

        public string Create(Fee fee)
        {
            feeRepo.Create(fee);

            return "";
        }

        public string Update(Fee fee)
        {
            feeRepo.Update(fee);
            return "";
        }


    }
}