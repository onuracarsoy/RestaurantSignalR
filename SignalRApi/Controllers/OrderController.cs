using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.OrderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : Controller
	{

		private readonly IOrderService _orderService;
		private readonly IMapper _mapper;

		public OrderController(IOrderService OrderService, IMapper mapper)
		{
			_orderService = OrderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetOrderList()
		{
			var result = _mapper.Map<List<ResultOrderDto>>(_orderService.TGetListAll());

			return Ok(result);
		}
		[HttpGet("GetActiveOrderCount")]
		public IActionResult GetOrderCount()
		{
			var OrderCount = _orderService.TGetActiveOrderCount();

			return Ok(OrderCount);
		}

		[HttpGet("GetOrderWithTable")]
		public IActionResult GetOrderWithTable()
		{
			var orderWithTable = _orderService.TGetOrderWithTable();

			return Ok(orderWithTable);
		}

		[HttpGet("GetOrdersPaidToday")]
		public IActionResult GetOrdersPaidToday()
		{
			var ordersPaidToday = _orderService.TGetOrdersPaidToday();

			return Ok(ordersPaidToday);
		}

		[HttpGet("GetUnPaidOrder")]
		public IActionResult GetUnPaidOrder()
		{
			var getUnPaidOrder = _orderService.TGetUnPaidOrders();

			return Ok(getUnPaidOrder);
		}

        [HttpGet("GetTodayUnPaidOrderCount")]
        public IActionResult GetTodayUnPaidOrderCount()
        {
            var getUnPaidOrder = _orderService.TGetTodayUnPaidOrderCount();

            return Ok(getUnPaidOrder);
        }

        [HttpGet("GetTodayPaidOrderCount")]
        public IActionResult GetTodayPaidOrderCount()
        {
            var getUnPaidOrder = _orderService.TGetTodayPaidOrderCount();

            return Ok(getUnPaidOrder);
        }

        [HttpGet("PayOrder/{id}")]
		public IActionResult PayOrder(int id)
		{
			 _orderService.TPayOrder(id);

			return Ok();
		}

		[HttpGet("GetByIDWithUnPaidOrder/{id}")]
		public IActionResult GetByIDWithUnPaidOrder(int id)
		{
			var getByIDWithUnPaidOrder = _orderService.TGetByIDWithUnPaidOrder(id);

			return Ok(getByIDWithUnPaidOrder);
		}

		[HttpGet("GetNewOrderIDWithTableID/{id}")]
		public IActionResult GetNewOrderIDWithTableID(int id)
		{
			var getNewOrderIDWithTableID = _orderService.TGetNewOrderIDWithTableID(id);

			return Ok(getNewOrderIDWithTableID);
		}

		[HttpGet("{id}")]
		public IActionResult GetByIDOrder(int id)
		{
			var value = _orderService.TGetByID(id);

			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateOrder(CreateOrderDto createOrderDto)
		{

			var value = _mapper.Map<Order>(createOrderDto);			
			_orderService.TAdd(value);

			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteOrder(int id)
		{
			var value = _orderService.TGetByID(id);
			_orderService.TDelete(value);
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateOrder(UpdateOrderDto updateOrderDto)
		{
			var value = _mapper.Map<Order>(updateOrderDto);
			_orderService.TUpdate(value);
			return Ok();
		}
	}
}
