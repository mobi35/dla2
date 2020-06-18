using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class SubjectAreaRepository : Repository<SubjectArea>, ISubjectAreaRepository
    {
        private readonly DLADBContext _context;
        public SubjectAreaRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

     
        public SubjectArea FindSubjectArea(Func<SubjectArea, bool> predicate)
        {
            return _context.SubjectAreas
                     .FirstOrDefault(predicate);
        }
    }
}
