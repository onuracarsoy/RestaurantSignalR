using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTableController : Controller
	{
		private readonly IMenuTableService _menuTableService;
		private readonly IMapper _mapper;

		public MenuTableController(IMenuTableService MenuTableService, IMapper mapper)
		{
			_menuTableService = MenuTableService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetMenuTableList()
		{
			var result = _mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll());

			return Ok(result);
		}
		[HttpGet("GetActiveMenuTableCount")]
		public IActionResult GetMenuTableCount()
		{
			var MenuTableCount = _menuTableService.TGetActiveTableCount();

			return Ok(MenuTableCount);
		}

		[HttpGet("GetPassiveTableCount")]
		public IActionResult GetPassiveTableCount()
		{
			var getPassiveTableCount = _menuTableService.TGetPassiveTableCount();

			return Ok(getPassiveTableCount);
		}
		
		[HttpGet("{id}")]
		public IActionResult GetByIDMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);

			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateMenuTable(CreateMenuTableDto createMenuTableDto)
		{

			var value = _mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.TAdd(value);

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteMenuTable(int id)
		{
			var value = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(value);
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateMenuTable(UpdateMenuTableDto updateMenuTableDto)
		{
			var value = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.TUpdate(value);
			return Ok();
		}
	}
}
