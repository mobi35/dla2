using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface ISectionRepository : IRepository<Section>
    {
        Section FindSection(Func<Section, bool> predicate);
    }
}
