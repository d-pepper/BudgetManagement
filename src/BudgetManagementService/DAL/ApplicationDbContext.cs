using MongoDB.Driver;
using BudgetManagementService.Models;
using BudgetManagementService.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace BudgetManagementService.DAL
{
    public class ApplicationDbContext : IApplicationDbContext
    {
        public IMongoCollection<Budget> Collection { get; set; }

        public ApplicationDbContext(IOptions<BudgetManagementConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(config.Value.DbName);

            Collection = database.GetCollection<Budget>("Budgets");
        }
    }
}
