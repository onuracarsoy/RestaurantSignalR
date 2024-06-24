using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCaseController : Controller
	{
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMapper _mapper;

		public MoneyCaseController(IMoneyCaseService MoneyCaseService, IMapper mapper)
		{
			_moneyCaseService = MoneyCaseService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetTotalMoneyCaseCount()
		{
			var totalMoneyCaseCount = _moneyCaseService.TTotalMoneyCaseCount();

			return Ok(totalMoneyCaseCount);
		}
	}
}
