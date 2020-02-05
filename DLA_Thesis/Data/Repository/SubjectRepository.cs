using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class SubjectRepository : Repository<Subject>, ISubjectRepository
    {
        private readonly DLADBContext _context;
        public SubjectRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

    

        public Subject FindSubject(Func<Subject, bool> predicate)
        {
            return _context.Subjects
                   .FirstOrDefault(predicate);
        }
    }
}
