using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private readonly DLADBContext _context;
        public SectionRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Section FindSection(Func<Section, bool> predicate)
        {
            return _context.Sections
                  .FirstOrDefault(predicate);
        }
    }
}
