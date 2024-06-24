using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderAndOrderDetailDto
{
	public class GetOrderDetailWithOrderDto
	{
		public int OrderDetailID { get; set; }

		public int OrderID { get; set; }

		public string TableName { get; set; }

		public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int ProductCount { get; set; }

		public decimal TotalPrice { get; set; }

		
	}
}
