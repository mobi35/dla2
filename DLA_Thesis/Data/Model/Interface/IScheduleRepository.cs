using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IScheduleRepository : IRepository<Schedule>
    {
        Schedule FindSchedule(Func<Schedule, bool> predicate);
    }
}
