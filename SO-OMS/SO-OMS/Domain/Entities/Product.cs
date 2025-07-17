namespace SO_OMS.Domain.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }
        public int? AlertThreshold { get; set; }
        public string Description { get; set; }  // null許容
        public bool IsPublished { get; set; }

        public Product() { } // パラメータレスコンストラクタ（EF用など）

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
