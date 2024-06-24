using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DtoLayer.OrderAndOrderDetailDto;
using SignalR.DtoLayer.OrderAndOrderDetailDtos;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;

        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

		public List<ResultOrderWithTableDto> TGetOrderWithTable()
		{
			return _orderDal.GetOrderWithTable();
		}

		public void TAdd(Order entity)
        {
            _orderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
           _orderDal.Delete(entity);
        }

		public int TGetActiveOrderCount()
		{
			return _orderDal.GetActiveOrderCount();
		}

		public Order TGetByID(int id)
        {
           return _orderDal.GetByID(id);    
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public void TUpdate(Order entity)
        {
           _orderDal.Update(entity);
        }

		public List<ResultOrdersPaidTodayDto> TGetOrdersPaidToday()
		{
			return _orderDal.GetOrdersPaidToday();
		}

		public List<ResultUnPaidOrdersDto> TGetUnPaidOrders()
		{
			return _orderDal.GetUnPaidOrders();
		}

        public GetByIDWithUnPaidOrderDto TGetByIDWithUnPaidOrder(int id)
        {
           return _orderDal.GetByIDWithUnPaidOrder(id);
        }

		public void TPayOrder(int id)
		{
			_orderDal.PayOrder(id);
		}

        public int TGetTodayUnPaidOrderCount()
        {
            return _orderDal.GetTodayUnPaidOrderCount();
        }

        public int TGetTodayPaidOrderCount()
        {
            return _orderDal.GetTodayPaidOrderCount();
        }

		public int TGetNewOrderIDWithTableID(int id)
		{
			return _orderDal.GetNewOrderIDWithTableID(id);
		}
	}
}
