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

        public IActionResult Delete(int id)
        {

            var fee = feeRepo.FindFee(a => a.FeeID == id);
            feeRepo.Delete(fee);

            return View("Index", feeRepo.GetAll());
        }
        public string Create(Fee fee)
        {
            var checkFee = feeRepo.FindFee(a => a.PaymentName == fee.PaymentName && a.GradeLevel == fee.GradeLevel);

            if(checkFee != null)
            {
                return "existing_name";
            }
            feeRepo.Create(fee);

            return "";
        }

        public string Update(Fee fee)
        {
            var checkFirstFee = feeRepo.FindFee(a => a.FeeID == fee.FeeID);

            var checkFee = feeRepo.FindFee(a => a.PaymentName == checkFirstFee.PaymentName && a.GradeLevel == fee.GradeLevel );

            if (checkFee == null)
            {
                return "existing_name";
            }

            checkFirstFee.PaymentPrice = fee.PaymentPrice;
            checkFirstFee.PaymentName = fee.PaymentName;
            checkFirstFee.GradeLevel = fee.GradeLevel;
            
            feeRepo.Update(checkFirstFee);
            return "";
        }


    }
}