using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        private readonly SignalRContext _context;
        public EfNotificationDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

		public void AllNotificationStatusChangeToTrue()
		{
			var allNotificationStatusChangeToTrue = _context.Notifications.Where(x => x.NotificationStatus == false).ToList();
            foreach (var item in allNotificationStatusChangeToTrue)
			{
				item.NotificationStatus = true;
			}
            _context.SaveChanges();
		}

		public List<Notification> GetAllNotificationsByFalse()
        {
            var getAllNotificationsByFalse = _context.Notifications.Where(x => x.NotificationStatus == false).OrderByDescending(x=>x.NotificationID).Take(5).ToList();
            return getAllNotificationsByFalse;
        }

        public int NotificationCountByStatusFalse()
        {
           var notificationCountByStatusFalse = _context.Notifications.Where(x => x.NotificationStatus == false).Count();
            return notificationCountByStatusFalse;
        }

		public void NotificationStatusChangeToFalse(int id)
		{
			var notification = _context.Notifications.Find(id);
            notification.NotificationStatus = false;
            _context.SaveChanges();
		}

		public void NotificationStatusChangeToTrue(int id)
		{
            var notification = _context.Notifications.Find(id);
			notification.NotificationStatus = true;
			_context.SaveChanges();
		}
	}
}
