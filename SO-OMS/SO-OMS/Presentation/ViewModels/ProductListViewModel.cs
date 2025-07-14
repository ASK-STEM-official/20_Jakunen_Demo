using System.Collections.Generic;

namespace SO_OMS.Presentation.ViewModels
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
        public string SearchProductName { get; set; }
        public string SearchProductId { get; set; }
        public string SearchCategory { get; set; }
        public bool ShowOnlyPublished { get; set; }
        public int ResultCount => Products?.Count ?? 0;
    }

    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsPublished { get; set; }
    }
} 