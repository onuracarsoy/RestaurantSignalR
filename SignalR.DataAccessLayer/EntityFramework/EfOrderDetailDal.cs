using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.DtoLayer.OrderAndOrderDetailDto;
using SignalR.DtoLayer.OrderDetailDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
    {
		private readonly SignalRContext _context;

        public EfOrderDetailDal(SignalRContext context) : base(context)
        {
			_context = context;
        }

		public List<GetOrderDetailWithOrderDto> GetOrderDetailsWithOrder(int id)
		{
			var orderDetailsWithOrder = (from o in _context.OrderDetails
								where o.OrderID == id
								join p in _context.Products
								on o.ProductID equals p.ProductID
								
								select new GetOrderDetailWithOrderDto
								{
									OrderDetailID = o.OrderDetailID,
									OrderID = o.OrderID,
									TableName = _context.Orders.Where(x => x.OrderID == id).Select(x => x.MenuTable.TableName).FirstOrDefault(),
									ProductName = p.ProductName,
									ProductPrice = p.ProductPrice,
									ProductCount = o.ProductCount,
									TotalPrice = o.TotalPrice
								}).ToList();
			return orderDetailsWithOrder;
		}
	}
}
