using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.SocialMediaDtos;

namespace SignalRWebUI.ViewComponents.MainLayoutComponents
{
    public class _MainLayoutFooterSocialMediaPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _MainLayoutFooterSocialMediaPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/SocialMedia/");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(content);
                return View(values);
            }
            return View();
           
        }
    }
}
