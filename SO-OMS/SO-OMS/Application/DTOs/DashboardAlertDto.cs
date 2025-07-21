using System;

namespace SO_OMS.Application.DTOs
{
    public class DashboardAlertDto
    {
        public int AlertID { get; set; }
        public int ProductID { get; set; }
        public DateTime DetectedAt { get; set; }
        public int? StockAtAlert { get; set; }
        public bool IsResolved { get; set; }
        public int? AlertThreshold { get; set; }
    }
}
