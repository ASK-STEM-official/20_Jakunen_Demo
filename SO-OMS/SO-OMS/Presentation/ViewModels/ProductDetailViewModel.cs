using System;

namespace SO_OMS.Presentation.ViewModels
{
    public class ProductDetailViewModel
    {
        public ProductViewModel Product { get; }

        public bool IsEditMode { get; } // true = 編集, false = 新規登録

        public ProductDetailViewModel(ProductViewModel product, bool isEditMode)
        {
            Product = product ?? throw new ArgumentNullException(nameof(product));
            IsEditMode = isEditMode;
        }

        public string Title => IsEditMode ? "商品編集" : "商品登録";

        public void UpdateFromForm(string name, string desc, decimal price, int stock, bool isPublished)
        {
            Product.ProductName = name;
            Product.Description = desc;
            Product.Price = price;
            Product.Stock = stock;
            Product.IsPublished = isPublished;
        }
    }
}
