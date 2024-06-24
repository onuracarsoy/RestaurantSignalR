namespace SignalRWebUI.Models.OrderAndOrderDetailDtos
{
	public class ResultOrderWithTableDto
	{
        public int OrderID { get; set; }

        public int MenuTableID { get; set; }

        public DateTime  OrderDate { get; set; }

        public string OrderDescription { get; set; }

		public decimal OrderTotalPrice { get; set; }

		public bool OrderStatus { get; set; }


	}
}
