using SO_OMS.Domain.Entities;
using SO_OMS.Domain.Services;
using System;
using System.Collections.Generic;

namespace SO_OMS.Application.Usecases.Products
{
    public class RegisterProductUseCase
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductValidationService _validationService;

        public RegisterProductUseCase(IProductRepository productRepository, ProductValidationService validationService)
        {
            _productRepository = productRepository;
            _validationService = validationService;
        }

        public void Execute(Product product)
        {
            var result = _validationService.Validate(product);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
            _productRepository.Insert(product);
        }
    }

    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public ValidationException(List<string> errors) : base(string.Join("\n", errors))
        {
            Errors = errors;
        }
    }
}