using SaveDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveDomain.Queries
{
    public interface IGetAllSavesQuery
    {
        Task<IEnumerable<Save>> Execute();
    }
}
