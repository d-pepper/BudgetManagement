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
    }
}
