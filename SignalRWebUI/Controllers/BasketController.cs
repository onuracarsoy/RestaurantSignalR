using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

using SignalRWebUI.Models.BasketDto;
using System.Reflection;
using System.Text;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class BasketController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            id = 1;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7044/api/Basket/GetBasketByTableNumber/"+id);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetBasketByTableNumber>>(content);



                decimal basketAllTotalPrice = 0;
                decimal basketAllTotalPriceTax = 0;
                decimal kdv = 20;
                decimal tax = 0;
               

                basketAllTotalPrice = values.Sum(x => x.ProductPrice);
                tax = basketAllTotalPrice / 100 * kdv;
                basketAllTotalPriceTax = basketAllTotalPrice + tax;

                
                ViewBag.basketAllTotalPrice = basketAllTotalPrice;
                ViewBag.kdv = kdv;
                ViewBag.tax = tax;
                ViewBag.basketAllTotalPriceTax = basketAllTotalPriceTax;


                return View(values);
            }
       
            return View();
        }

        public async Task<IActionResult> DeleteItem(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7044/api/Basket/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }

       
    }
}
