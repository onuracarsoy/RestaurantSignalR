using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        private readonly SignalRContext _context;
        public EfBookingDal(SignalRContext context) : base(context)
        {
           _context = context;
        }

		public int GetTodayBookingCount()
		{
			var todayBookingCount = _context.Bookings.Where(x => x.BookingDate == DateTime.Now.Date && x.BookingStatus == true).Count();
            return todayBookingCount;
		}

        public int GetTodayWaitBookingCount()
        {
            var todayBookingCount = _context.Bookings.Where(x => x.BookingDate == DateTime.Now.Date && x.BookingStatus == false).Count();
            return todayBookingCount;
        }
    }
}
