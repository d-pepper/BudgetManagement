using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetManagementService.Models;
using MongoDB.Bson;

namespace BudgetManagementService.DAL
{
    public class Repository : IRepository
    {
        private IApplicationDbContext _context;

        public Repository(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            return await _context.Collection.FindAsync<Budget>(new BsonDocument()).Result.ToListAsync();
        }
    }
}
