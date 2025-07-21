using SO_OMS.Application.Usecases.Products;
using SO_OMS.Domain.Utils;
using System.Collections.Generic;
using System.Linq;

namespace SO_OMS.Presentation.ViewModels
{
    public class ProductListViewModel
    {
        private readonly ListProductsUseCase _usecase;

        public ProductListViewModel(ListProductsUseCase usecase)
        {
            _usecase = usecase;
        }

        public List<ProductViewModel> Products { get; private set; } = new List<ProductViewModel>();
        public string SearchProductName { get; set; }
        public string SearchProductId { get; set; }
        public string SearchCategory { get; set; }
        public bool ShowOnlyPublished { get; set; }
        public int ResultCount => Products?.Count ?? 0;

        public void LoadProducts()
        {
            var results = _usecase.Execute(
                SearchProductId,
                SearchProductName,
                TryParseCategoryId(SearchCategory),
                ShowOnlyPublished
            );

            Products = results.Select(p => new ProductViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Category = CategoryResolver.GetName(p.CategoryID),
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock,
                IsPublished = p.IsPublished,
                AlertThreshold = p.AlertThreshold
            }).ToList();
        }

        private int? TryParseCategoryId(string input)
        {
            if (int.TryParse(input, out var result))
                return result;
            return null;
        }
    }
}
