using System;

namespace SO_OMS.Domain.Entities
{
    public class AlertLog
    {
        public int AlertID { get; set; }           // アラートID（主キー）
        public int ProductID { get; set; }         // 対象商品ID（外部キー）
        public string ProductName { get; set; }    // 商品名（JOINされた情報）
        public int StockAtAlert { get; set; }      // アラート発生時の在庫数
        public DateTime DetectedAt { get; set; }   // アラート検出日時
        public bool IsResolved { get; set; }       // 対応済みフラグ（true:対応済）
    }
}
