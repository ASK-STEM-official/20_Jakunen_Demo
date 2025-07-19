using SO_OMS.Domain.Entities;
using System.Collections.Generic;

namespace SO_OMS.Domain.Services
{
    public class ProductValidationService
    {
        public ValidationResult Validate(Product product)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(product.ProductName))
                errors.Add("商品名は必須です。");

            if (product.Price <= 0)
                errors.Add("価格は1円以上で入力してください。");

            if (product.Stock < 0)
                errors.Add("在庫数は0以上を入力してください。");

            if (product.AlertThreshold.HasValue && product.AlertThreshold.Value < 0)
                errors.Add("在庫アラートしきい値は0以上を入力してください。");

            return new ValidationResult(errors);
        }
    }

    public class ValidationResult
    {
        public List<string> Errors { get; }
        public bool IsValid => Errors.Count == 0;

        public ValidationResult(List<string> errors)
        {
            Errors = errors;
        }
    }
}