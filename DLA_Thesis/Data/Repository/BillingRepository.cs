using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model;
using DLA_Thesis.Data.Model.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Repository
{
    public class BillingRepository : Repository<Billing>, IBillingRepository
    {
        private readonly DLADBContext _context;
        public BillingRepository(DLADBContext context) : base(context)
        {
            _context =  context;
        }

        public Billing FindBilling(Func<Billing, bool> predicate)
        {
            return _context.Bilings
                    .FirstOrDefault(predicate);
        }
    }
}
