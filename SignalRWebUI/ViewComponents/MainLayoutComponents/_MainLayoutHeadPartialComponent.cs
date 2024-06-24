using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MainLayoutComponents
{
    public class _MainLayoutHeadPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
