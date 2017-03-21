using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManagementService.Models;

namespace BudgetManagementService.DAL
{
    public interface IRepository
    {
        void Add(Budget budget);
        Task<IEnumerable<Budget>> GetAll();
    }
}
