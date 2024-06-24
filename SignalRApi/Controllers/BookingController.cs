using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, INotificationService notificationService, IMapper mapper)
        {
            _bookingService = bookingService;
            _notificationService = notificationService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIDBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }
		[HttpGet("GetTodayBookingCount")]
		public IActionResult GetTodayBookingCount(int id)
		{
			var value = _bookingService.TGetTodayBookingCount();
			return Ok(value);
		}

        [HttpGet("GetTodayWaitBookingCount")]
        public IActionResult GetTodayWaitBookingCount(int id)
        {
            var value = _bookingService.TGetTodayWaitBookingCount();
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var value = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(value);

            Notification notification = new Notification();
            {
                notification.NotificationDescription = "Yeni Rezervasyon!";
                notification.NotificationType = "notif-icon notif-primary";
                notification.NotificationIcon = "la la-key";
                notification.NotificationDate = DateTime.Now;
                notification.NotificationStatus = false;
            }
            _notificationService.TAdd(notification);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var value = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(value);
            return Ok();
        }

    }
}
