using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Models.CategoryDtos;
using SignalRWebUI.Models.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/Product/GetProductsWithCategories");
            if (response.IsSuccessStatusCode)
            {
				var content = await response.Content.ReadAsStringAsync();
				var products = JsonConvert.DeserializeObject<List<GetProductsWithCategoriesDto>>(content);
                return View(products);

				
			}
        
            return View();
        }


		[HttpGet]
		public async Task<IActionResult> Create()
		{
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/Category");
            var content = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
            IEnumerable<SelectListItem> selectListItems = (from x in category
                                                        select new SelectListItem
                                                        {
                                                            Text = x.CategoryName,
                                                            Value = x.CategoryID.ToString()
                                                        }).ToList();
            ViewBag.Categories = selectListItems;
                                                    
            return View();
           
        
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateProductDto createProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7044/api/Product", stringContent);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7044/api/Product/" + id);
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

           
            var response = await client.GetAsync("https://localhost:7044/api/Category");
            var content = await response.Content.ReadAsStringAsync();
            var category = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(content);
            IEnumerable<SelectListItem> selectListItems = (from x in category
                                                           select new SelectListItem
                                                           {
                                                               Text = x.CategoryName,
                                                               Value = x.CategoryID.ToString()
                                                           }).ToList();
            ViewBag.Categories = selectListItems;

            var responseMessage = await client.GetAsync("https://localhost:7044/api/Product/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);

                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7044/api/Product", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
