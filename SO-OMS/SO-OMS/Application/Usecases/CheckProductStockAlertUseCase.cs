using System;
using System.Collections.Generic;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Usecases
{
    public class CheckProductStockAlertUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly IAlertLogRepository _alertLogRepository;

        public CheckProductStockAlertUseCase(
            IProductRepository productRepository,
            IAlertLogRepository alertLogRepository)
        {
            _productRepository = productRepository;
            _alertLogRepository = alertLogRepository;
        }

        public void Execute()
        {
            var allProducts = _productRepository.Search(null, null, null, false); // 出品状態に関係なく取得

            foreach (var product in allProducts)
            {
                if (product.AlertThreshold.HasValue && product.Stock < product.AlertThreshold.Value)
                {
                    var latest = _alertLogRepository.GetLatestAlert(product.ProductID);
                    if (latest == null || latest.DetectedAt.Date != DateTime.Today)
                    {
                        var alert = new AlertLog
                        {
                            ProductID = product.ProductID,
                            StockAtAlert = product.Stock,
                            DetectedAt = DateTime.Now,
                            IsResolved = false
                        };
                        _alertLogRepository.Add(alert);
                    }
                }
            }
        }
    }
}
