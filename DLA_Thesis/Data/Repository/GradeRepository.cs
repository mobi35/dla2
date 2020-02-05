using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        private readonly DLADBContext _context;
        public GradeRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Grade FindGrade(Func<Grade, bool> predicate)
        {
            return _context.Grades
                   .FirstOrDefault(predicate);
        }

     
    }
}
