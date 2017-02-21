using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BudgetManagementService.Configuration;

using MongoDB.Bson;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace BudgetManagementService.Controllers
{
    public class IndexController : Controller
    {

    }

    public class DbContext
    {
        public IMongoCollection<Budget> BudgetCollection;

        public DbContext(IOptions<DbConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);

            BudgetCollection = database.GetCollection<Budget>("Budgets");
        }
    }

    public class Repository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> IEnumerable<Budget> GetAll()
        {           
            return await _context.BudgetCollection.Find(new BsonDocument()).ToListAsync();
            
        }
    }

    public class Budget
    {
        public string Name { get; set; }
        public ICollection<Dictionary<string, double>> Incomings;
        public ICollection<Dictionary<string, double>> Outgoings;
    }
}
