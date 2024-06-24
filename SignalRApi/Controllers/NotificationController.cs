using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : Controller
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationController(INotificationService NotificationService, IMapper mapper)
		{
			_notificationService = NotificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetNotificationList()
		{
			var result = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());

			return Ok(result);
		}
		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			var value = _notificationService.TNotificationCountByStatusFalse();

			return Ok(value);
		}

		[HttpGet("GetAllNotificationsByFalse")]
		public IActionResult GetAllNotificationsByFalse()
		{
			var value = _notificationService.TGetAllNotificationsByFalse();

			return Ok(value);
		}

		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);

			return Ok();
		}

		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);

			return Ok();
		}
		
		[HttpGet("AllNotificationStatusChangeToTrue")]
		public IActionResult AllNotificationStatusChangeToTrue()
		{
			_notificationService.TAllNotificationStatusChangeToTrue();
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult GetByIDNotification(int id)
		{
			var value = _notificationService.TGetByID(id);

			return Ok(value);
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{

			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);

			return Ok();
		}


		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok();
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var value = _mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(value);
			return Ok();
		}
	}
}
