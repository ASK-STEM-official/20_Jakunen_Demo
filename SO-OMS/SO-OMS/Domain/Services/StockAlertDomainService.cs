using SO_OMS.Domain.Entities;

namespace SO_OMS.Domain.Services
{
    public class StockAlertDomainService
    {
        public bool NeedsStockAlert(Product product)
        {
            return product.AlertThreshold.HasValue && product.Stock < product.AlertThreshold.Value;
        }
    }
}