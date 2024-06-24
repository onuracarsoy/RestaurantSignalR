using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.OrderDto
{
    public class CreateOrderDto
    {

       

        public int MenuTableID { get; set; }

        public string OrderDescription { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public bool OrderStatus { get; set; }

    }
}
