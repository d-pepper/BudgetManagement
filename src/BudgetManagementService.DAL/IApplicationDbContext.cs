using MongoDB.Driver;
using BudgetManagementService.Models;

namespace BudgetManagementService.DAL
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Budget> BudgetCollection { get; set; }
    }
}
