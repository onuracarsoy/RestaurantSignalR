using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDetailDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailController : ControllerBase
	{
		private readonly IOrderDetailService _orderDetailService;
		private readonly IMapper _mapper;

		public OrderDetailController(IOrderDetailService OrderDetailService, IMapper mapper)
		{
			_orderDetailService = OrderDetailService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetOrderDetailList()
		{
			var result = _mapper.Map<List<ResultOrderDetailDto>>(_orderDetailService.TGetListAll());

			return Ok(result);
		}


		[HttpGet("{id}")]
		public IActionResult GetByIDOrderDetail(int id)
		{
			var value = _orderDetailService.TGetByID(id);

			return Ok(value);
		}

		[HttpGet("GetOrderDetailsWithOrder/{id}")]
		public IActionResult GetOrderDetailsWithOrder(int id)
		{
			var value = _orderDetailService.TGetOrderDetailsWithOrder(id);
			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateOrderDetail(CreateOrderDetailDto createOrderDetailDto)
		{

			var value = _mapper.Map<OrderDetail>(createOrderDetailDto);
			_orderDetailService.TAdd(value);

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteOrderDetail(int id)
		{
			var value = _orderDetailService.TGetByID(id);
			_orderDetailService.TDelete(value);
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateOrderDetail(UpdateOrderDetailDto updateOrderDetailDto)
		{
			var value = _mapper.Map<OrderDetail>(updateOrderDetailDto);
			_orderDetailService.TUpdate(value);
			return Ok();
		}
	}
}
