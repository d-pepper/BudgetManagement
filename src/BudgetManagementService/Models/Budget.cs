using System.Collections.Generic;
using MongoDB.Bson;

namespace BudgetManagementService.Models
{
    public class Budget
    {
        public  ObjectId Id { get; set; }
        public string Name { get; set; }
        public ICollection<Dictionary<string, double>> Incomings;
        public ICollection<Dictionary<string, double>> Outgoings;
    }
}
