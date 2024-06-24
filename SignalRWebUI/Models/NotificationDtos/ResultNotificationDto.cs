﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.NotificationDto
{
    public class ResultNotificationDto
    {

        public int NotificationID { get; set; }

        public string NotificationIcon { get; set; }

        public string NotificationType { get; set; }

        public string NotificationDescription { get; set; }

        public DateTime NotificationDate { get; set; }

        public bool NotificationStatus { get; set; }
    }
}
