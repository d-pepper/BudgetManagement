using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementService.Models
{
    public class Budget
    {
        public string Name { get; set; }
        public ICollection<Dictionary<string, double>> Incomings;
        public ICollection<Dictionary<string, double>> Outgoings;
    }
}
