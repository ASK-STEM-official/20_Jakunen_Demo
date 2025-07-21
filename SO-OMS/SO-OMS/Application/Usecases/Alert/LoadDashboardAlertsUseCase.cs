using System.Collections.Generic;
using SO_OMS.Application.Interfaces;
using SO_OMS.Application.DTOs;

namespace SO_OMS.Application.Usecases.Alert
{
    public class LoadDashboardAlertsUseCase
    {
        private readonly IAlertLogRepository _alertLogRepository;

        public LoadDashboardAlertsUseCase(IAlertLogRepository alertLogRepository)
        {
            _alertLogRepository = alertLogRepository;
        }

        public List<DashboardAlertDto> Execute()
        {
            return _alertLogRepository.GetDashboardAlerts();
        }
    }
}
