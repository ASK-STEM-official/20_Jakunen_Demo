using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Usecases
{
    public class ResolveAlertUseCase
    {
        private readonly IAlertLogRepository _alertRepository;

        public ResolveAlertUseCase(IAlertLogRepository alertRepository)
        {
            _alertRepository = alertRepository;
        }

        public void Execute(int alertId, bool isResolved)
        {
            var alert = _alertRepository.GetById(alertId);
            if (alert == null) return;

            alert.IsResolved = isResolved;
            _alertRepository.Update(alert);
        }
    }
}
