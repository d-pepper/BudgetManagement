using Microsoft.AspNetCore.Mvc;
using BudgetManagementService.DAL;

namespace BudgetManagementService.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repository;

        public HomeController(IRepository repository)
        {
            _repository = repository;
        }

        public string Index()
        {


            return "Hello World!";
        }
    }
}
