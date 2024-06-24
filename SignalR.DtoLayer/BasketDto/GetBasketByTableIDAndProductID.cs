﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.BasketDto
{
    public class GetBasketByTableIDAndProductID
    {

        public int BasketID { get; set; }

        public int MenuTableID { get; set; }

        public int ProductID { get; set; }

        public string ProductName { get; set; }

        public decimal ProductPrice { get; set; }

        public int BasketProductCount { get; set; }

        public decimal BasketTotalPrice { get; set; }
    }
}
