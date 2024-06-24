using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MainLayoutComponents
{
    public class _MainLayoutNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
