using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.OrderAndOrderDetailDto;

namespace SignalRWebUI.Controllers
{
	public class OrderDetailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderDetailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/OrderDetail/GetOrderDetailsWithOrder/"+id);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetOrderDetailWithOrderDto>>(content);
				return View(values);
			}
			return View();
		}

	}
}
