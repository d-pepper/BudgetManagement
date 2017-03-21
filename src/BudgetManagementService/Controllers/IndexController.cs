using Microsoft.AspNetCore.Mvc;
using BudgetManagementService.DAL;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Budgets()
        {
            var budgets = await _repository.GetAll();
            return new OkObjectResult(budgets);
        }

        public IActionResult PostBudget(BudgetRequest budget)
        {
            //Map request to dto

            //_repository.Add(budget);

            return new OkResult();
        }
    }
}
