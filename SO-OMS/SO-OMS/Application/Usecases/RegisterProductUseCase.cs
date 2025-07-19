using SO_OMS.Domain.Entities;
using SO_OMS.Application.Interfaces;

namespace SO_OMS.Application.Usecases
{
    public class RegisterProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public RegisterProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(Product product)
        {
            _productRepository.Insert(product);
        }
    }
}
