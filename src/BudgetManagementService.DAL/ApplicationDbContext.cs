using MongoDB.Driver;
using BudgetManagementService.Models;
using Microsoft.Extensions.Options;

namespace BudgetManagementService.DAL
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Budget> BudgetCollection { get; set; }

        public ApplicationDbContext(IOptions<DbConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);
            
            BudgetCollection = database.GetCollection<Budget>("budgets");
        }
    }
}