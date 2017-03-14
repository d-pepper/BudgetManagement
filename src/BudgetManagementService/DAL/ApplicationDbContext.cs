using MongoDB.Driver;
using BudgetManagementService.Models;
using BudgetManagementService.Configuration;
using Microsoft.Extensions.Options;

namespace BudgetManagementService.DAL
{
    public class ApplicationDbContext
    {
        public IMongoCollection<Budget> BudgetCollection;

        public ApplicationDbContext(IOptions<BudgetManagementConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);

            BudgetCollection = database.GetCollection<Budget>("Budgets");
        }
    }
}
