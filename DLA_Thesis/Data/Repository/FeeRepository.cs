using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class FeeRepository : Repository<Fee>, IFeeRepository
    {
        private readonly DLADBContext _context;
        public FeeRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Fee FindFee(Func<Fee, bool> predicate)
        {
            return _context.Fees
                    .FirstOrDefault(predicate);
        }
    }
}
