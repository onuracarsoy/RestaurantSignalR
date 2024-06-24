using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using SignalRWebUI.Models.AboutDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutPartialComponent :ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/About/"+2);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAboutDto>(content);
                return View(values);
            }
            return View();
        }
    }
}
