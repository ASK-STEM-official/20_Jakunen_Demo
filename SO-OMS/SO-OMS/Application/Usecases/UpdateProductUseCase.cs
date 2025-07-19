using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Domain.Services;
using SO_OMS.Presentation.ViewModels;
using System;

namespace SO_OMS.Application.Usecases
{
    public class UpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly StockAlertDomainService _alertService;
        private readonly IAlertLogRepository _alertLogRepository;

        public UpdateProductUseCase(
            IProductRepository productRepository,
            StockAlertDomainService alertService,
            IAlertLogRepository alertLogRepository)
        {
            _productRepository = productRepository;
            _alertService = alertService;
            _alertLogRepository = alertLogRepository;
        }

        public void Execute(ProductViewModel viewModel)
        {
            var product = new Product
            {
                ProductID = viewModel.ProductID,
                ProductName = viewModel.ProductName,
                Description = viewModel.Description,
                Price = viewModel.Price,
                Stock = viewModel.Stock,
                CategoryID = ParseCategoryId(viewModel.Category),
                IsPublished = viewModel.IsPublished,
                AlertThreshold = viewModel.AlertThreshold
            };

            _productRepository.Update(product);

            if (_alertService.NeedsStockAlert(product))
            {
                var latestAlert = _alertLogRepository.GetLatestAlert(product.ProductID);

                if (latestAlert == null || latestAlert.IsResolved)
                {
                    var newAlert = new AlertLog
                    {
                        ProductID = product.ProductID,
                        DetectedAt = DateTime.Now,
                        StockAtAlert = product.Stock,
                        IsResolved = false
                    };

                    _alertLogRepository.Add(newAlert);
                }
            }
        }

        private int ParseCategoryId(string categoryName)
        {
            if (categoryName == "食品") return 1;
            if (categoryName == "雑貨") return 2;
            return 3;
        }
    }
}
