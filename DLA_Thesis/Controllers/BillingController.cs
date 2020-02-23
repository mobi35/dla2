using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;
using Microsoft.AspNetCore.Mvc;


namespace DLA_Thesis.Controllers
{
    public class BillingController : Controller
    {
        private readonly IFeeRepository feeRepo;
        private readonly IBillingRepository billingRepo;
        private readonly ITeacherRepository teacherRepo;
      
        private readonly IStudentRepository studentRepo;

        public BillingController(IFeeRepository feeRepo, IBillingRepository billingRepo, ITeacherRepository teacherRepo,  IStudentRepository studentRepo)
        {
            this.feeRepo = feeRepo;
            this.billingRepo = billingRepo;
            this.teacherRepo = teacherRepo;
            this.studentRepo = studentRepo;
        }

        public IActionResult Index()
        {
            return View(billingRepo.GetAll());
        }

        public IActionResult Create(Billing billing)
        {
            billingRepo.Create(billing);
            return View("Index");
        }

        public IActionResult Student()
        {
            return View();
        }

        public JsonResult MyBillings(string username)
        {
           var student = studentRepo.FindStudent(a => a.LRN == username);
           var ListOfFees =  feeRepo.GetAll().Where(a => a.GradeLevel == student.CurrentGrade);
            return Json(ListOfFees);
        }

    }
}