using System;
using System.Collections.Generic;
using System.Linq;

namespace SO_OMS.Domain.Entities
{
    public class OrderReservation
    {
        public string ReservationID { get; set; }
        public DateTime ReservationDateTime { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        public DateTime ImportedDateTime { get; set; }

        public List<OrderReservationItem> Items { get; set; }

        public int GetTotalQuantity()
        {
            return Items?.Sum(i => i.Quantity) ?? 0;
        }

        public string GetProductName()
        {
            return Items?.FirstOrDefault()?.ProductName ?? string.Empty;
        }
    }
}
