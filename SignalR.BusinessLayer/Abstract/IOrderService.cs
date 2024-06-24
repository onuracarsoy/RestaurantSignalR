using SignalR.DtoLayer.OrderAndOrderDetailDto;
using SignalR.DtoLayer.OrderAndOrderDetailDtos;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
		int TGetActiveOrderCount();

		List<ResultOrderWithTableDto> TGetOrderWithTable();

		List<ResultOrdersPaidTodayDto> TGetOrdersPaidToday();

		 List<ResultUnPaidOrdersDto> TGetUnPaidOrders();

        GetByIDWithUnPaidOrderDto TGetByIDWithUnPaidOrder(int id);

		void TPayOrder(int id);

        int TGetTodayUnPaidOrderCount();

        int TGetTodayPaidOrderCount();

		int TGetNewOrderIDWithTableID(int id);



	}
}
