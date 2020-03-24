using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly DLADBContext _context;
        public RoomRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Room FindRoom(Func<Room, bool> predicate)
        {
            return _context.Rooms
                    .FirstOrDefault(predicate);
        }
    }
}
