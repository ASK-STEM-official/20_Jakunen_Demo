using System.Collections.Generic;
using SO_OMS.Application.Interfaces;
using SO_OMS.Presentation.ViewModels;

namespace SO_OMS.Application.Usecases
{
    public class LoadDashboardAlertsUseCase
    {
        private readonly IAlertLogRepository _alertRepository;

        public LoadDashboardAlertsUseCase(IAlertLogRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public List<DashboardAlertViewModel> Execute()
        {
            return _alertRepository.GetAll();
        }
    }
}
