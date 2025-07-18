using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
            var allProducts = _productRepository.Search(null, null, null, false); // 全商品取得

            foreach (var product in allProducts)
            {
                if (!product.AlertThreshold.HasValue) continue;

                if (product.Stock >= product.AlertThreshold.Value) continue;

                var latest = _alertLogRepository.GetLatestAlert(product.ProductID);

                // 最新が null（初回）または「解決済み」ならアラート出す
                if (latest == null || latest.IsResolved)
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
