namespace SO_OMS.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; }
        public string ProductName { get; }
        public decimal Price { get; }
        public int Stock { get; }
        public int CategoryID { get; }
        public int? AlertThreshold { get; }
        public string Description { get; }
        public bool IsPublished { get; }

        public Product(int productID, string productName, decimal price, int stock, int categoryID, int? alertThreshold, string description, bool isPublished)
        {
            ProductID = productID;
            ProductName = productName;
            Price = price;
            Stock = stock;
            CategoryID = categoryID;
            AlertThreshold = alertThreshold;
            Description = description;
            IsPublished = isPublished;
        }
    }
}