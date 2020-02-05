using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class ScheduleRepository : Repository<Schedule>, IScheduleRepository
    {
        private readonly DLADBContext _context;
        public ScheduleRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

     
        public Schedule FindSchedule(Func<Schedule, bool> predicate)
        {
            return _context.Schedules
                     .FirstOrDefault(predicate);
        }
    }
}
