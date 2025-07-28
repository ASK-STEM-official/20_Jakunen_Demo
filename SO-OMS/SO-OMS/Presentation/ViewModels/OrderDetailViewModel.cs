using System;
using System.Collections.Generic;
using SO_OMS.Presentation.ViewModels;

public class OrderDetailViewModel
{
    public string ReservationID { get; set; }
    public int CustomerID { get; set; }
    public string CustomerName { get; set; }
    public string PhoneNumber { get; set; }
    public string ShippingAddress { get; set; }
    public string PaymentMethod { get; set; }
    public string Status { get; set; }
    public DateTime? ChangeDateTime { get; set; }
    public DateTime ReservationDate { get; set; }
    public DateTime? ImportedDateTime { get; set; }

    public decimal TotalAmount { get; set; }

    public List<OrderItemViewModel> Items { get; set; }
}
