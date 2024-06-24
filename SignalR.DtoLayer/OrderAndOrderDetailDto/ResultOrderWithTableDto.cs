namespace SignalR.DtoLayer.OrderAndOrderDetailDtos
{
	public class ResultOrderWithTableDto
	{
        public int OrderID { get; set; }

        public string TableName{ get; set; }

        public DateTime  OrderDate { get; set; }

        public string OrderDescription { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public bool OrderStatus { get; set; }


	}
}
