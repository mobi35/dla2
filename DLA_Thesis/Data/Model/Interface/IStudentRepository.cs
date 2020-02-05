using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IStudentRepository : IRepository<Student>
    {
        Student FindStudent(Func<Student, bool> predicate);
    }
}
