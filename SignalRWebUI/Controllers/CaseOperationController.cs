using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class CaseOperationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
