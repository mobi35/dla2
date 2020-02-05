using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly DLADBContext _context;
        public StudentRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Student FindStudent(Func<Student, bool> predicate)
        {
            return _context.Students
                  .FirstOrDefault(predicate);
        }
    }
}
