using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IGradeRepository : IRepository<Grade>
    {
        Grade FindGrade(Func<Grade, bool> predicate);
    }
}
