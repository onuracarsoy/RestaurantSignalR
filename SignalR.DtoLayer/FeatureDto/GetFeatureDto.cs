﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDto
{
    public class GetFeatureDto
    {
        public int FeatureID { get; set; }

        public string FeatureTitle { get; set; }

        public string FeatureDescription { get; set; }

        public bool FeatureStatus { get; set; }
    }
}
