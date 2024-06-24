using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class Order
    {
        public int OrderID { get; set; }

        public int MenuTableID { get; set; }
        public MenuTable MenuTable { get; set; }

        public string OrderDescription { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal OrderTotalPrice { get; set; }

        public bool OrderStatus { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}
