using Casgem_ChainOfResponsibility.ChainOfResponsibilityPattern;
using Casgem_ChainOfResponsibility.Models;
using Microsoft.AspNetCore.Mvc;

namespace Casgem_ChainOfResponsibility.Controllers
{
    public class DefaultController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel p)
        {
            Employee treauser = new Treasurer();
            Employee managerAssistant = new ManagerAssistant();
            Employee manager = new Manager();
            Employee areaDirector = new AreaDirector();

            treauser.SetNextApprover(managerAssistant);
            managerAssistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treauser.ProcessRequest(p);

            return RedirectToAction("Index");

        }
    }
}
