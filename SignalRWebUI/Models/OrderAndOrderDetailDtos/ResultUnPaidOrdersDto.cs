using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.OrderAndOrderDetailDto
{
	public class ResultUnPaidOrdersDto
	{
		public int OrderID { get; set; }

		

		public string TableName { get; set; }

		public DateTime OrderDate { get; set; }

		public string OrderDescription { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public bool OrderStatus { get; set; }
	}
}
