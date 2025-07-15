using System;
namespace SO_OMS.Presentation.ViewModels
{
    public class DashboardAlertViewModel
    {
        public int AlertID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? AlertThreshold { get; set; }
        public int StockAtAlert { get; set; }
        public DateTime DetectedAt { get; set; }
        public bool IsResolved { get; set; }
    }
}
