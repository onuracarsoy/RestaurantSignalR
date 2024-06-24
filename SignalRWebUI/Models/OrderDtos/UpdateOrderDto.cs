using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.OrderDto
{
    public class UpdateOrderDto
    {
        public int OrderID { get; set; }

		public int ProductID { get; set; }

		public string OrderDescription { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public bool OrderStatus { get; set; }

		public int OrderDetailID { get; set; }

		public int MenuTableID { get; set; }

		public string TableName { get; set; }

		public string ProductName { get; set; }

		public int ProductCount { get; set; }

		public decimal TotalPrice { get; set; }

	}
}
