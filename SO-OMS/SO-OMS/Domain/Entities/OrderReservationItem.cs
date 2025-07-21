namespace SO_OMS.Domain.Entities
{
    public class OrderReservationItem
    {
        public int ItemID { get; set; }
        public string ReservationID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => UnitPrice * Quantity;
    }
}
