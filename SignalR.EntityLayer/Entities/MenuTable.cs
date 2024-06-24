using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.EntityLayer.Entities
{
    public class MenuTable
    {
        public int MenuTableID { get; set; }

        public string TableName { get; set; }

        public bool TableStatus { get; set; }

        public List<Order> Orders { get; set; }
        public List<Basket> Baskets { get; set; }

    }
}
