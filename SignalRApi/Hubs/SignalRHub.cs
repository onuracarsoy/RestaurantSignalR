using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IMenuTableService _menuTableService;
        private readonly IOrderService _orderService;
        private readonly IBookingService _bookingService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly INotificationService _notificationService;

        public SignalRHub(ICategoryService categoryService, IProductService productService, IMenuTableService menuTableService, IOrderService orderService, IBookingService bookingService, IMoneyCaseService moneyCaseService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _menuTableService = menuTableService;
            _orderService = orderService;
            _bookingService = bookingService;
            _moneyCaseService = moneyCaseService;
            _notificationService = notificationService;
        }

        public async Task SendCategoryCount()
        {
            var value = _categoryService.TGetCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
        public async Task SendActiveCategoryCount()
        {
            var value = _categoryService.TGetActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
        }
        public async Task SendPassiveCategoryCount()
        {
            var value = _categoryService.TGetPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value);
        }

        public async Task SendProductCount()
        {
            var value = _productService.TGetProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value);
        }

        public async Task SendActiveProductCount()
        {
            var value = _productService.TGetActiveProductCount();
            await Clients.All.SendAsync("ReceiveActiveProductCount", value);
        }

        public async Task SendPassiveProductCount()
        {
            var value = _productService.TGetPassiveProductCount();
            await Clients.All.SendAsync("ReceivePassiveProductCount", value);
        }

        public async Task SendActiveTableCount()
        {
            var value = _menuTableService.TGetActiveTableCount();
            await Clients.All.SendAsync("ReceiveActiveTableCount", value);

        }

		public async Task SendActiveOrderCount()
		{
			var value = _orderService.TGetActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value);

		}

		public async Task SendTodayBookingCount()
		{
			var value = _bookingService.TGetTodayBookingCount();
			await Clients.All.SendAsync("ReceiveTodayBookingCount", value);

		}
        
        public async Task SendTodayWaitBookingCount()
		{
			var value = _bookingService.TGetTodayWaitBookingCount();
			await Clients.All.SendAsync("ReceiveTodayWaitBookingCount", value);

		}

		public async Task SendTotalMoneyCaseCount()
		{
			var value = _moneyCaseService.TTotalMoneyCaseCount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseCount", value.ToString("0.00")+ "₺");

		}

        public async Task SendNotificationCountByStatusFalse()
        {
            var value = _notificationService.TNotificationCountByStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountByStatusFalse", value);

        }

        public async Task SendGetAllNotificationsByFalse()
        {
            var value = _notificationService.TGetAllNotificationsByFalse();
            await Clients.All.SendAsync("ReceiveGetAllNotificationsByFalse", value);

        }

		public async Task SendMenuTableStatus()
		{
			var value = _menuTableService.TGetListAll();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);

		}

        public async Task SendMessage(string user, string message)
        {

		     //user = Context.User.Identity.Name ?? "Anonymous";
			await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public static int userCount { get; set; } = 0;
        public override async Task OnConnectedAsync()
        {
            userCount++;
            await Clients.All.SendAsync("ReceiveActiveUser", userCount);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            userCount--;
            await Clients.All.SendAsync("ReceiveActiveUser", userCount);
            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendGetTodayUnPaidOrderCount()
        {
            var value = _orderService.TGetTodayUnPaidOrderCount();
            await Clients.All.SendAsync("ReceiveGetTodayUnPaidOrderCount", value);

        }

        public async Task SendGetTodayPaidOrderCount()
        {
            var value = _orderService.TGetTodayPaidOrderCount();
            await Clients.All.SendAsync("ReceiveGetTodayPaidOrderCount", value);

        }
        
        public async Task SendGetPassiveTableCount()
        {
            var value = _menuTableService.TGetPassiveTableCount();
            await Clients.All.SendAsync("ReceiveGetPassiveTableCount", value);

        }
    }
}
