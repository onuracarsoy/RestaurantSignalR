using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.OrderDto
{
    public class ResultOrderDto
    {

        public int OrderID { get; set; }

		public int ProductID { get; set; }

		public string OrderDescription { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public bool OrderStatus { get; set; }

    }
}
