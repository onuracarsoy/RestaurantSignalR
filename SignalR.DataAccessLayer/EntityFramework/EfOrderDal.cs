using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.OrderAndOrderDetailDto;
using SignalR.DtoLayer.OrderAndOrderDetailDtos;
using SignalR.DtoLayer.OrderDetailDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
		private readonly SignalRContext _context;
        public EfOrderDal(SignalRContext context) : base(context)
        {
			_context = context;
        }


		public int GetActiveOrderCount()
		{
			var activeOrderCount = _context.Orders.Where(x => x.OrderStatus == true).Count();	
			return activeOrderCount;

		}

        public GetByIDWithUnPaidOrderDto GetByIDWithUnPaidOrder(int id)
        {
            var order = (from o in _context.Orders
                         where o.OrderID == id
                         join t in _context.MenuTables
                         on o.MenuTableID equals t.MenuTableID
                         select new GetByIDWithUnPaidOrderDto
                         {
                             OrderID = o.OrderID,
                             TableName = t.TableName,
                             MenuTableID = t.MenuTableID,
                             OrderDate = o.OrderDate,
                             OrderDescription = o.OrderDescription,
                             OrderTotalPrice = o.OrderTotalPrice,
                             OrderStatus = o.OrderStatus
                         }).FirstOrDefault();
			return order;
        }

		public int GetNewOrderIDWithTableID(int id)
		{
			var newOrderID = _context.Orders.Where(x => x.MenuTableID == id && x.OrderStatus == true).OrderByDescending(x=>x.OrderDate).Select(x => x.OrderID).FirstOrDefault();
			return newOrderID;
		}

		public List<ResultOrdersPaidTodayDto> GetOrdersPaidToday()
		{
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var ordersPaidToday = (from o in _context.Orders
								   where o.OrderDate < tomorrow && o.OrderStatus == false
								   join t in _context.MenuTables
								   on o.MenuTableID equals t.MenuTableID
								   select new ResultOrdersPaidTodayDto
								   {
									   OrderID = o.OrderID,
									   TableName = t.TableName,
									   OrderDate = o.OrderDate,
									   OrderDescription = o.OrderDescription,
									   OrderTotalPrice = o.OrderTotalPrice,
									   OrderStatus = o.OrderStatus
								   }).ToList();

			return ordersPaidToday;
		}
		
		public List<ResultOrderWithTableDto> GetOrderWithTable()
		{
			var resultOrderWithTables= (from o in _context.Orders
						  join t in _context.MenuTables
						  on o.MenuTableID equals t.MenuTableID
						  select new ResultOrderWithTableDto
						  {
							  OrderID = o.OrderID,
							  TableName = t.TableName,
							  OrderDate = o.OrderDate,
							  OrderDescription = o.OrderDescription,
							  OrderTotalPrice = o.OrderTotalPrice,
							  OrderStatus = o.OrderStatus
						  }).ToList();

			return resultOrderWithTables;
		}

        public int GetTodayPaidOrderCount()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var getpaidOrderCount = _context.Orders.Where(x => x.OrderStatus == false && x.OrderDate < tomorrow).Count();
			return getpaidOrderCount;

        }

        public int GetTodayUnPaidOrderCount()
        {
            var today = DateTime.Today;
            var tomorrow = today.AddDays(1);
            var getUnPaidOrderCount = _context.Orders.Where(x => x.OrderStatus == true && x.OrderDate < tomorrow).Count();
            return getUnPaidOrderCount;
        }

        public List<ResultUnPaidOrdersDto> GetUnPaidOrders()
		{
			var unPaidOrders = (from o in _context.Orders
								where o.OrderStatus == true
								join t in _context.MenuTables
								on o.MenuTableID equals t.MenuTableID
								select new ResultUnPaidOrdersDto
								{
									OrderID = o.OrderID,
									TableName = t.TableName,
									OrderDate = o.OrderDate,
									OrderDescription = o.OrderDescription,
									OrderTotalPrice = o.OrderTotalPrice,
									OrderStatus = o.OrderStatus
								}).ToList();
			return unPaidOrders;	
		}

		public void PayOrder(int id)
		{
			var order = _context.Orders.Find(id);
			order.OrderStatus = false;
			_context.SaveChanges();
		}
	}
}
