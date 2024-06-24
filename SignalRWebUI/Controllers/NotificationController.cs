using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Models.NotificationDto;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class NotificationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/Notification");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(content);
				return View(values);
			}
			return View();
		}


		public async Task<IActionResult> NotificationStatusChangeToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			 await client.GetAsync("https://localhost:7044/api/Notification/NotificationStatusChangeToTrue/" + id);
			
			return RedirectToAction("Index");
		}

		public async Task<IActionResult> NotificationStatusChangeToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7044/api/Notification/NotificationStatusChangeToFalse/" + id);

			return RedirectToAction("Index");
		}
		
		public async Task<IActionResult> AllNotificationStatusChangeToTrue()
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7044/api/Notification/AllNotificationStatusChangeToTrue");

			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateNotificationDto createNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7044/api/Notification", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7044/api/Notification/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7044/api/Notification/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);

				return View(value);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateNotificationDto updateNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7044/api/Notification", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{

				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
