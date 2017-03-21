using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetManagementService.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BudgetManagementService.DAL
{
    public class BudgetRepository : IRepository
    {
        private IApplicationDbContext _context;

        public BudgetRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Budget budget)
        {
            _context.BudgetCollection.InsertOneAsync(budget);
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            var collection = _context.BudgetCollection;
            var results = await collection.Find(new BsonDocument()).ToListAsync();

            return results;
        }
    }
}
