using SO_OMS.Domain.Entities;
using SO_OMS.Application.Interfaces;

namespace SO_OMS.Application.Usecases
{
    public class GetProductDetailUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductDetailUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(int productId)
        {
            return _productRepository.GetById(productId);
        }
    }
}
