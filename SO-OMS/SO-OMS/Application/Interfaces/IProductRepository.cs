using SO_OMS.Domain.Entities;
using System.Collections.Generic;

public interface IProductRepository
{
    List<Product> Search(string productIdKeyword, string productNameKeyword, int? categoryId, bool isPublishedOnly);
    Product GetById(int productId);
    void Insert(Product product);
    void Update(Product product);
}
