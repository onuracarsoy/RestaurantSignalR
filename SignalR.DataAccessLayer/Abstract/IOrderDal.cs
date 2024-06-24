
using SignalR.DtoLayer.OrderAndOrderDetailDto;
using SignalR.DtoLayer.OrderAndOrderDetailDtos;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        public List<ResultOrderWithTableDto> GetOrderWithTable();
        public List<ResultOrdersPaidTodayDto> GetOrdersPaidToday();
        public List<ResultUnPaidOrdersDto> GetUnPaidOrders();
        public int GetActiveOrderCount();
        public GetByIDWithUnPaidOrderDto GetByIDWithUnPaidOrder(int id);
        public void PayOrder(int id);
        public int  GetTodayUnPaidOrderCount();
        public int  GetTodayPaidOrderCount();
        public int  GetNewOrderIDWithTableID(int id);

    }
}
