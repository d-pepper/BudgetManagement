using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementService.DAL
{
    public interface IRepository
    {
        Task<IEnumerable<Budget>> GetAll();
    }
}
