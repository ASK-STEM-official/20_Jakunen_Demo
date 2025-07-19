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
        private readonly IAlertLogRepository _alertLogRepository;
        private readonly StockAlertDomainService _alertService;
        private readonly ProductValidationService _validationService;

        public UpdateProductUseCase(
            IProductRepository productRepository,
            IAlertLogRepository alertLogRepository,
            StockAlertDomainService alertService,
            ProductValidationService validationService
            )

        {
            _productRepository = productRepository;
            _alertLogRepository = alertLogRepository;
            _alertService = alertService;
            _validationService = validationService;

        }

        public void Execute(Product product)
        {
            var result = _validationService.Validate(product);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
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
    }
}
