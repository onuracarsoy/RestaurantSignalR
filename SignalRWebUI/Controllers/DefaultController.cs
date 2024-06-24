using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalR.DtoLayer.BookingDto;
using SignalRWebUI.Models.AboutDtos;
using SignalRWebUI.Models.BasketDto;
using SignalRWebUI.Models.CategoryDtos;
using SignalRWebUI.Models.MenuTableDtos;
using SignalRWebUI.Models.ProductDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Menu()
        {


            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/Category");
            var content = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
            IEnumerable<ResultCategoryDto> selectListItems = (from x in category
                                                              select new ResultCategoryDto
                                                              {
                                                                  CategoryName = x.CategoryName,
                                                                  CategoryStatus = x.CategoryStatus,
                                                                  CategoryID = x.CategoryID
                                                              }).ToList();
            ViewBag.Categories = selectListItems;

            var client2 = _httpClientFactory.CreateClient();
            var response2 = await client2.GetAsync("https://localhost:7044/api/Product/GetProductsWithCategories");

            if (response2.IsSuccessStatusCode)
            {
                var content2 = await response2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<GetProductsWithCategoriesDto>>(content2);
                return View(values2);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket([FromBody] CreateBasketDto createBasketDto)
        {
            createBasketDto.MenuTableID = 1;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7044/api/Basket", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return Ok(new { message = "Ürün sepete eklendi." });
            }

            return BadRequest(new { message = "Ürün sepete eklenirken bir hata oluştu." });
        }

      

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Book()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Book(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7044/api/Booking", stringContent);
            if (response.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Index");
            }

            return View();
          
        }


    }
}
