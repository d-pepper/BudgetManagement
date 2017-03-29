using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetManagementService.ViewModels
{
    public class BudgetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Dictionary<string, double>> Incomings { get; set; }
        public IEnumerable<Dictionary<string, double>> Outgoings { get; set; }
    }
}
