using SignalRWebUI.Models.OrderAndOrderDetailDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

using SignalRWebUI.Models.OrderAndOrderDetailDtos;
using System.Text;

using SignalRWebUI.Models.OrderDto;
using System.ComponentModel;
using SignalRWebUI.Models.MenuTableDtos;
using SignalRWebUI.Models.OrderDetailDto;
using Humanizer.Localisation.TimeToClockNotation;
using SignalRWebUI.Models.CategoryDtos;
using SignalRWebUI.Models.ProductDtos;



namespace SignalRWebUI.Controllers
{
	public class OrderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/Order/GetOrderWithTable");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOrderWithTableDto>>(content);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreateOrder()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/MenuTable");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(content);
				return View(values);
			}
			return View();
		}



		public async Task<IActionResult> AddOrder(int id, CreateOrderDto createOrderDto)
		{
			createOrderDto.MenuTableID = id;
			createOrderDto.OrderDate = DateTime.Now;
			createOrderDto.OrderStatus = true;
			createOrderDto.OrderTotalPrice = 0;
			createOrderDto.OrderDescription = "";

			var client = _httpClientFactory.CreateClient();

			var jsonData = JsonConvert.SerializeObject(createOrderDto);

			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7044/api/Order", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("AddOrderWithProduct", "Order",id);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> AddOrderWithProduct()
		{
          

            return View();
        }
		[HttpPost]
		public async Task<IActionResult> AddOrderWithProduct([FromBody] CreateOrderDetailDto createOrderDetailDto)
		{
			var client2 = _httpClientFactory.CreateClient();
			var response2 = await client2.GetAsync("https://localhost:7044/api/Order/GetNewOrderIDWithTableID/" + 1);
			var content2 = await response2.Content.ReadAsStringAsync();
			var values2 = JsonConvert.DeserializeObject<int>(content2);

			var orderid = values2;

            createOrderDetailDto.OrderID = orderid ;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createOrderDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7044/api/OrderDetail", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "Ürün sepete eklendi." });
            }

            return BadRequest(new { message = "Ürün sepete eklenirken bir hata oluştu." });

            //var client = _httpClientFactory.CreateClient();
            //createOrderDetailDto.OrderID = orderid ;

            //var jsonData = JsonConvert.SerializeObject(createOrderDetailDto);
            //StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            //var response = await client.PostAsync("https://localhost:7044/api/OrderDetail", stringContent);
            //if (response.IsSuccessStatusCode)
            //{
            //	return RedirectToAction("Index", "CaseOperation");
            //}

            //return View();
        }

		public async Task<IActionResult> OrdersPaidToday()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/Order/GetOrdersPaidToday");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOrdersPaidTodayDto>>(content);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> UnPaidOrders()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/Order/GetUnPaidOrder");
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultUnPaidOrdersDto>>(content);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> GetUnPaidOrderDetail(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7044/api/OrderDetail/GetOrderDetailsWithOrder/" + id);
			if (response.IsSuccessStatusCode)
			{
				var content = await response.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetOrderDetailWithOrderDto>>(content);
				return View(values);
			}
			return View();
		}

		public async Task<IActionResult> PayOrder(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7044/api/Order/PayOrder/" + id);

			return RedirectToAction("Index", "CaseOperation");
		}






		//[HttpGet]
		//public IActionResult CreateOrder()
		//{
		//	return View();
		//}
		//[HttpPost]
		//public async Task<IActionResult> CreateOrder(CreateOrderAndOrderDetailDto createOrderAndOrderDetailDto)
		//{
		//	var products = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
		//	IEnumerable<SelectListItem> selectListItems = (from x in category
		//												   select new SelectListItem
		//												   {
		//													   Text = x.CategoryName,
		//													   Value = x.CategoryID.ToString()
		//												   }).ToList();
		//	ViewBag.Categories = selectListItems;

		//	var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
		//	IEnumerable<SelectListItem> selectListItems = (from x in category
		//												   select new SelectListItem
		//												   {
		//													   Text = x.CategoryName,
		//													   Value = x.CategoryID.ToString()
		//												   }).ToList();
		//	ViewBag.Categories = selectListItems;


		//	var client = _httpClientFactory.CreateClient();
		//	var jsonData1 = JsonConvert.SerializeObject(createOrderAndOrderDetailDto);
		//	StringContent stringContent1 = new StringContent(jsonData1, Encoding.UTF8, "application/json");
		//	var response1 = await client.PostAsync("https://localhost:7044/api/Order", stringContent1);


		//	var jsonData2 = JsonConvert.SerializeObject(createOrderAndOrderDetailDto);
		//	StringContent stringContent2 = new StringContent(jsonData1, Encoding.UTF8, "application/json");
		//	var response2 = await client.PostAsync("https://localhost:7044/api/OrderDetail", stringContent2);


		//	if (response1.IsSuccessStatusCode)
		//	{
		//		return RedirectToAction("Index");
		//	}

		//	return View();
		//}

		public async Task<IActionResult> Delete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7044/api/Order/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		//[HttpGet]
		//public async Task<IActionResult> PayOrder(int id)
		//{
		//	var client = _httpClientFactory.CreateClient();


		//	var response = await client.GetAsync("https://localhost:7044/api/MenuTable");
		//	var content = await response.Content.ReadAsStringAsync();
		//	var tables = JsonConvert.DeserializeObject<List<ResultMenuTableDto>>(content);
		//	IEnumerable<SelectListItem> selectListItems = (from x in tables
		//												   select new SelectListItem

		//												   {
		//													   Text = x.TableName,
		//													   Value = x.MenuTableID.ToString()
		//												   }).ToList();
		//	ViewBag.Tables = selectListItems;

		//	var client2 = _httpClientFactory.CreateClient();
		//	var responseMessage2 = await client2.GetAsync("https://localhost:7044/api/Order/" + id);
		//	if (responseMessage2.IsSuccessStatusCode)
		//	{
		//		var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
		//		var value = JsonConvert.DeserializeObject<UpdateOrderDto>(jsonData2);

		//		return View(value);
		//	}
		//	return View();
		//}

		//[HttpPost]
		//public async Task<IActionResult> PayOrder(UpdateOrderDto updateOrderDto)
		//{
		//	var client = _httpClientFactory.CreateClient();
		//	var jsonData = JsonConvert.SerializeObject(updateOrderDto);
		//	StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
		//	var responseMessage = await client.PutAsync("https://localhost:7044/api/Order", stringContent);
		//	if (responseMessage.IsSuccessStatusCode)
		//	{

		//		return RedirectToAction("Index");
		//	}
		//	return View();
		//}
	}
}
