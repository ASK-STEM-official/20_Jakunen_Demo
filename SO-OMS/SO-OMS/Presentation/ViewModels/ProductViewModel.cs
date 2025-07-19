namespace SO_OMS.Presentation.ViewModels
{
    public class ProductViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; } // 表示名
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int? AlertThreshold { get; set; }
        public bool IsPublished { get; set; }

        public string PublishStatus => IsPublished ? "出品中" : "停止中";
    }
}
