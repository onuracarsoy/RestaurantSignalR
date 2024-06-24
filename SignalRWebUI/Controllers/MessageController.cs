using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
           var username =  User.Identity.Name;
            ViewBag.username = username;
            return View();
        }
    }
}
