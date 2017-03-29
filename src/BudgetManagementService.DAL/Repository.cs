using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BudgetManagementService.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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

        public async Task<Budget> Find(string id)
        {
            return await _context.BudgetCollection.Find(x => x.Id == ObjectId.Parse(id)).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Budget>> GetAll()
        {
            var collection = _context.BudgetCollection;
            var results = await collection.Find(new BsonDocument()).ToListAsync();

            return results;
        }

        public async Task Add(Budget budget)
        {
            await _context.BudgetCollection.InsertOneAsync(budget);
        }

        public async Task Update(Budget budget)
        {
            var collection = _context.BudgetCollection;
            var filter = Builders<Budget>.Filter.Eq(x=> x.Id, budget.Id);

            var update = Builders<Budget>.Update
                .Set(x => x.Incomings, budget.Incomings)
                .Set(x => x.Outgoings, budget.Outgoings)
                .Set(x => x.Name, budget.Name);
                //Fix this    .CurrentDate("lastModified");

            var result = await collection.UpdateOneAsync(filter, update);
        }
    }
}