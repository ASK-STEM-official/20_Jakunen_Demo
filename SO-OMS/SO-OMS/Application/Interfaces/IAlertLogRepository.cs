using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;
using System.Collections.Generic;

namespace SO_OMS.Application.Interfaces
{
    public interface IAlertLogRepository
    {
        List<DashboardAlertViewModel> GetAll();
        void Update(AlertLog alertLog);
    }
}