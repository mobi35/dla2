﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DLA_Thesis.Data.Model.Interface
{
    public interface ISubjectAreaRepository : IRepository<SubjectArea>
    {
        SubjectArea FindSubjectArea(Func<SubjectArea, bool> predicate);
    }
}
