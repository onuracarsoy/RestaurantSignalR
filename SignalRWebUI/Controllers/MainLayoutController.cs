using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class MainLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
