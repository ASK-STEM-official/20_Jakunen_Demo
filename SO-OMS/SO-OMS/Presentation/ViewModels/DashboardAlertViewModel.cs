using System.Collections.Generic;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Presentation.ViewModels
{
    public class DashboardAlertViewModel
    {
        public List<AlertLog> Alerts { get; set; } = new List<AlertLog>();
    }
}
