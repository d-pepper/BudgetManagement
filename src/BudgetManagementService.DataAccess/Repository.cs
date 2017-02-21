using System.Collections.Generic;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using BudgetManagementService.Configuration;
using BudgetManagementService.DataAccess.Models;

namespace BudgetManagementService.DataAccess
{
    public class DbContext
    {
        // Move into config
        public const string CONNECTION_STRING_NAME = "Blog";
        public const string DATABASE_NAME = "blog";
        public const string POSTS_COLLECTION_NAME = "posts";
        public const string USERS_COLLECTION_NAME = "users";

        public DbContext(IOptions<DbConfiguration> config)
        {
            var connectionString = config.Value.ConnectionString;
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(DATABASE_NAME);
        }
    }

    public class Repository
    {
        private DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public IEnumerable<Budget> GetAll()
        {
            return _context
        }
    }
}
