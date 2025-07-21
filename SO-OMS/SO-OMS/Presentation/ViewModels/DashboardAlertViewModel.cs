using SO_OMS.Application.DTOs;
using System;

namespace SO_OMS.Presentation.ViewModels
{
    public class DashboardAlertViewModel
    {
        public int AlertID { get; set; }
        public int ProductID { get; set; }
        public DateTime DetectedAt { get; set; }
        public int? StockAtAlert { get; set; }
        public bool IsResolved { get; set; }
        public int? AlertThreshold { get; set; }

        public static DashboardAlertViewModel FromDto(DashboardAlertDto dto)
        {
            return new DashboardAlertViewModel
            {
                AlertID = dto.AlertID,
                ProductID = dto.ProductID,
                DetectedAt = dto.DetectedAt,
                StockAtAlert = dto.StockAtAlert,
                IsResolved = dto.IsResolved,
                AlertThreshold = dto.AlertThreshold
            };
        }
    }
}
