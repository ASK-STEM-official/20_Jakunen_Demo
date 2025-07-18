using System.Collections.Generic;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;

namespace SO_OMS.Application.Interfaces
{
    public interface IAlertLogRepository
    {
        List<DashboardAlertViewModel> GetAll();
        AlertLog GetById(int alertId);
        void Update(AlertLog alert);
        void Add(AlertLog alert);
        AlertLog GetLatestAlert(int productId);
    }
}
