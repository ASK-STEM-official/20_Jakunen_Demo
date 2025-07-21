using System;

namespace SO_OMS.Presentation.ViewModels
{
    public class OrderListViewModel
    {
        public string ReservationID { get; set; }
        public string CustomerName { get; set; }
        public string ProductName { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public string OrderStatus { get; set; }
    }
}
