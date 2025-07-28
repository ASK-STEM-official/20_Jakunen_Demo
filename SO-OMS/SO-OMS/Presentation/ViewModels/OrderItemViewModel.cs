namespace SO_OMS.Presentation.ViewModels
{
    public class OrderItemViewModel
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal TaxRate { get; set; }
        public decimal Subtotal { get; set; }
    }

}
