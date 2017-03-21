using MongoDB.Driver;
using BudgetManagementService.Configuration;
using Microsoft.Extensions.Options;
using BudgetManagementService.Models;

namespace BudgetManagementService.DAL
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Budget> BudgetCollection { get; set; }

        public ApplicationDbContext(IOptions<AppConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);
            
            BudgetCollection = database.GetCollection<Budget>("budgets");
        }
    }
}
