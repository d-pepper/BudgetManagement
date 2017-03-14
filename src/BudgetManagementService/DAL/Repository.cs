using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManagementService.Models;

namespace BudgetManagementService.DAL
{
    public class Repository : IRepository
    {
        private ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            return await _context.BudgetCollection.Find<Budget>().ToListAsync();
        }
    }
}
