﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Models.DiscountDtos
{
    public class CreateDiscountDto
    {

        public string DiscountTitle { get; set; }

        public string DiscountAmount { get; set; }

        public string DiscountImageUrl { get; set; }
    }
}
