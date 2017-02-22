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
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IOptions<BudgetManagementConfiguration> config, IRepository repository)
        {
            _repository = repository;
        }

        public string Index()
        {
            var repository = new Repository();

            return "Hello World!";
        }
    }

    public class DbContext
    {
        public IMongoCollection<Budget> BudgetCollection;

        public DbContext(IOptions<BudgetManagementConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);

            BudgetCollection = database.GetCollection<Budget>("Budgets");
        }
    }

    public interface IRepository
    {
        Task<IEnumerable<Budget>> GetAll();
    }

    public class Repository : IRepository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Budget>> GetAll()
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
