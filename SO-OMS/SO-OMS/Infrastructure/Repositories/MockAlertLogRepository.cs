using System;
using System.Collections.Generic;
using SO_OMS.Domain.Entities;
using SO_OMS.Application.Interfaces;

namespace SO_OMS.Infrastructure.Repositories
{
    public class MockAlertLogRepository : IAlertLogRepository
    {
        private readonly List<AlertLog> _alerts = new List<AlertLog>
        {
            new AlertLog
            {
                AlertID = 1,
                ProductID = 101,
                ProductName = "オリーブオイルA",
                StockAtAlert = 2,
                AlertThreshold = 5,
                DetectedAt = DateTime.Now.AddHours(-2),
                IsResolved = false
            },
            new AlertLog
            {
                AlertID = 2,
                ProductID = 102,
                ProductName = "オリーブオイルB",
                StockAtAlert = 0,
                AlertThreshold = 3,
                DetectedAt = DateTime.Now.AddHours(-5),
                IsResolved = true
            }
        };

        public List<AlertLog> GetAll()
        {
            return _alerts;
        }

        public void Update(AlertLog alertLog)
        {
            var existing = _alerts.Find(a => a.AlertID == alertLog.AlertID);
            if (existing != null)
            {
                existing.IsResolved = alertLog.IsResolved;
            }
        }
    }
}
