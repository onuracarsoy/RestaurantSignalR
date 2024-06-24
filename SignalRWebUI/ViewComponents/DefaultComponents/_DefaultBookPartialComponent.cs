using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.BookingDtos;
using System.Text;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBookPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public IViewComponentResult Invoke()
        {
            return View();

        }


    }
}
