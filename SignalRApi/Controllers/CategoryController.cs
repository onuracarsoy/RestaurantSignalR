using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCategoryList()
        {
            var result = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());

            return Ok(result);
        }
		[HttpGet("GetCategoryCount")]
		public IActionResult GetCategoryCount()
		{
			var categoryCount = _categoryService.TGetCategoryCount();

			return Ok(categoryCount);
		}
		[HttpGet("GetActiveCategoryCount")]
		public IActionResult GetActiveCategoryCount()
		{
			var categoryCount = _categoryService.TGetActiveCategoryCount();

			return Ok(categoryCount);
		}
		[HttpGet("GetPassiveCategoryCount")]
		public IActionResult GetPassiveCategoryCount()
		{
			var categoryCount = _categoryService.TGetPassiveCategoryCount();

			return Ok(categoryCount);
		}

		[HttpGet("{id}")]
        public IActionResult GetByIDCategory(int id)
        {
            var value = _categoryService.TGetByID(id);

            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var value = _mapper.Map<Category>(createCategoryDto);
            _categoryService.TAdd(value);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            _categoryService.TUpdate(value);
            return Ok();
        }
    }
}
