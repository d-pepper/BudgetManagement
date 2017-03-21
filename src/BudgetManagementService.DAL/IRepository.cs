using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManagementService.Models;

namespace BudgetManagementService.DAL
{
    public interface IRepository
    {        
        Task<IEnumerable<Budget>> GetAll();
        void Add(Budget budget);
        void Update(Budget budget);
        Task<Budget> Find(string id);
    }
}
