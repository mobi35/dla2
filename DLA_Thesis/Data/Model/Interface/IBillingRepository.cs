using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IBillingRepository : IRepository<Billing>
    {
        Billing FindBilling(Func<Billing, bool> predicate);
    }
}
