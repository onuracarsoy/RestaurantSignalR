using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MainLayoutComponents
{
    public class _MainLayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
