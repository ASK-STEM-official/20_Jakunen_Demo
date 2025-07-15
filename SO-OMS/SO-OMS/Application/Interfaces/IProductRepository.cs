using System.Collections.Generic;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Application.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product FindById(int productId);
        IEnumerable<Product> GetLowStockProducts(); // しきい値未満の商品
    }
}