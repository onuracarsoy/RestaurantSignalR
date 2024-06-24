using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using SignalRWebUI.Models.ContactDtos;

namespace SignalRWebUI.ViewComponents.MainLayoutComponents
{
    public class _MainLayoutFooterPartialComponent :ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _MainLayoutFooterPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/Contact/" + 1);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetContactDto>(content);
                return View(values);
            }
            return View();
        }
    }
}
