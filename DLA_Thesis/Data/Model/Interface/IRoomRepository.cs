using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IRoomRepository : IRepository<Room>
    {
        Room FindRoom(Func<Room, bool> predicate);
    }
}
