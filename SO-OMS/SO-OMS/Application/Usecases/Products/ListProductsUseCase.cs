using SO_OMS.Domain.Entities;
using SO_OMS.Application.Interfaces;
using System.Collections.Generic;

namespace SO_OMS.Application.Usecases.Products
{
    public class ListProductsUseCase
    {
        private readonly IProductRepository _productRepository;

        public ListProductsUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> Execute(string productIdKeyword, string productNameKeyword, int? categoryId, bool isPublishedOnly)
        {
            return _productRepository.Search(productIdKeyword, productNameKeyword, categoryId, isPublishedOnly);
        }
    }
}
