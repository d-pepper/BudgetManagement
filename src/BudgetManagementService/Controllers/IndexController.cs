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
        public IActionResult GetById(string id)
        {
            var item = _repository.Find(id);

            if (item == null)
            {
                return NotFound();
            }

            return new ObjectResult(item);
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

            //Return created object to determine success. Find a nicer way to do this
            //return new OkObjectResult(model);
            return CreatedAtRoute("GetBudget", new { id = model.Id }, model);
        }
    }

    public class BudgetViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Dictionary<string, double>> Incomings { get; set; }
        public IEnumerable<Dictionary<string, double>> Outgoings { get; set; }
    }
}



