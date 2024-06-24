using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService ProductService, IMapper mapper)
        {
            _productService = ProductService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProductList()
        {
            var result = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());

            return Ok(result);
        }
		[HttpGet("GetProductCount")]
		public IActionResult GetProductCount()
		{
			var productCount = _productService.TGetProductCount();

			return Ok(productCount);
		}

		[HttpGet("GetActiveProductCount")]
		public IActionResult GetActiveProductCount()
		{
			var getActiveProductCount = _productService.TGetActiveProductCount();

			return Ok(getActiveProductCount);
		}

		[HttpGet("GetPassiveProductCount")]
		public IActionResult GetPassiveProductCount()
		{
			var getPassiveProductCount = _productService.TGetPassiveProductCount();

			return Ok(getPassiveProductCount);
		}

		[HttpGet("{id}")]
        public IActionResult GetByIDProduct(int id)
        {
            var value = _productService.TGetByID(id);

            return Ok(value);
        }

        [HttpGet("GetProductsWithCategories")]
        public IActionResult GetProductsWithCategories()
        {
            var values = _mapper.Map<List<GetProductsWithCategoriesDto>>(_productService.TGetProductsWithCategories());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {

            var value = _mapper.Map<Product>(createProductDto);
            _productService.TAdd(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetByID(id);
            _productService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _productService.TUpdate(value);
            return Ok();
        }
    }
}
