using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal : IGenericDal<Notification>
	{
		public int NotificationCountByStatusFalse();

		public List<Notification> GetAllNotificationsByFalse();

		public void NotificationStatusChangeToTrue(int id);

		public void AllNotificationStatusChangeToTrue();

		public void NotificationStatusChangeToFalse(int id);
	}
}
