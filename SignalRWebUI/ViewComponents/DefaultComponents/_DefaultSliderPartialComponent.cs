using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.FeatureDtos;
using System.Net.Http;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultSliderPartialComponent(IHttpClientFactory clientFactory)
		{
			_httpClientFactory = clientFactory;
		}


		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/Feature");
			
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(content);
				return View(values);
			}
			return View();
		}

	
	}
}
