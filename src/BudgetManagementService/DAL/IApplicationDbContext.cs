using MongoDB.Driver;
using BudgetManagementService.Models;
using BudgetManagementService.Configuration;
using Microsoft.Extensions.Options;

namespace BudgetManagementService.DAL
{
    public interface IApplicationDbContext
    {
        IMongoCollection<Budget> Collection { get; set; }
    }
}
