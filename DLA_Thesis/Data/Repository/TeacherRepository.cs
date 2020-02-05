using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        private readonly DLADBContext _context;
        public TeacherRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Teacher FindTeacher(Func<Teacher, bool> predicate)
        {
            return _context.Teachers
                    .FirstOrDefault(predicate);
        }
    }
}
