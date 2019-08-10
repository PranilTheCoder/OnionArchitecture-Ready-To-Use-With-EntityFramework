using PranilArchitecture.Service;
using System.Web.Mvc;

namespace PranilArchitecture.Controllers
{
    public class HomeController : Controller
    {
        private readonly IExpenseTypeService _expenseTypeService;
        public HomeController(IExpenseTypeService expenseTypeService)
        {
            this._expenseTypeService = expenseTypeService;
        }
        public ActionResult Index()
        {
            var home = this._expenseTypeService.GetAllExpenseType();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}