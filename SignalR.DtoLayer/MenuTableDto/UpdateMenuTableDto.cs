﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.MenuTableDto
{
	public class UpdateMenuTableDto
	{
		public int MenuTableID { get; set; }

		public string TableName { get; set; }

		public bool TableStatus { get; set; }
	}
}
