using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.OrderDetailDto
{
    public class CreateOrderDetailDto
    {
   

        public int ProductCount { get; set; }

        public decimal TotalPrice { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }
    }
}
