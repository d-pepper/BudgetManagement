using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using BudgetManagementService.DAL;
using System.Linq;
using BudgetManagementService.Models;
using BudgetManagementService.ViewModels;

namespace BudgetManagementService.Controllers
{
    //Add shared path
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
        public async Task<IActionResult> GetAll()
        {
            var budgets = await _repository.GetAll();

            //Move to mapper/service
            var response = budgets.Select(x => new BudgetViewModel {
                Id = x.Id.ToString(),
                Name = x.Name,
                Incomings = x.Incomings,
                Outgoings = x.Outgoings
            });

            return new ObjectResult(response);
        }

        [HttpGet("budgets/{id}", Name = "GetBudget")]
        public async Task<IActionResult> GetById(string id)
        {
            var budget = await _repository.Find(id);

            if (budget == null)
            {
                return NotFound();
            }

            //Move to mapper/service
            var response = new BudgetViewModel();
            response.Id = budget.Id.ToString();
            response.Name = budget.Name;
            response.Incomings = budget.Incomings;
            response.Outgoings = budget.Outgoings;


            return new ObjectResult(response);
        }

        [HttpPost("budgets")]
        public IActionResult CreateNewBudget([FromBody] BudgetViewModel budget)
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

            return CreatedAtRoute("GetBudget", new { id = model.Id }, model);
        }

        [HttpPut("budgets/{id}")]
        public async  Task<IActionResult> Update(string id, [FromBody] BudgetViewModel item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            var budget = await _repository.Find(id);
            if (budget == null)
            {
                return NotFound();
            }

            budget.Name = item.Name;
            budget.Incomings = item.Incomings;
            budget.Outgoings = item.Outgoings;

            _repository.Update(budget);

            return new NoContentResult();
        }
    }
}



