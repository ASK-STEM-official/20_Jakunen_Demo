using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Usecases.Products
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
