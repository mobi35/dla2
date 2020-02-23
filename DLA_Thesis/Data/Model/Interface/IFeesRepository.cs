using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface IFeeRepository : IRepository<Fee>
    {
        Fee FindFee(Func<Fee, bool> predicate);
    }
}
