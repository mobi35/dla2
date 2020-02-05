using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Subject FindSubject(Func<Subject, bool> predicate);
    }
}
