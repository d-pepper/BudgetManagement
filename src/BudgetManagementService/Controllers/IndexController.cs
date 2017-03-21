using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using BudgetManagementService.DAL;
using System.Linq;
using BudgetManagementService.Models;

namespace BudgetManagementService.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return new OkResult();
        }

        [HttpGet]
        [Route("budgets")]
        public async Task<IActionResult> GetBudgets()
        {
            var budgets = await _repository.GetAll();

            //Move to mapper/service
            var response = budgets.Select(x => new BudgetViewModel {
                Name = x.Name,
                Incomings = x.Incomings,
                Outgoings = x.Outgoings
            });

            return new OkObjectResult(response);
        }

        [HttpPost]
        [Route("budgets")]
        public IActionResult PostBudget(BudgetViewModel budget)
        {
            if(budget == null)
            {
                return new BadRequestResult();
            }

            //Map request to dto
            var model = new Budget()
            {
                Name = budget.Name,
                Outgoings = budget.Outgoings,
                Incomings = budget.Incomings
            };


            _repository.Add(model);

            return new OkResult();
        }
    }

    public class BudgetViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Dictionary<string, double>> Incomings { get; set; }
        public IEnumerable<Dictionary<string, double>> Outgoings { get; set; }
    }
}



