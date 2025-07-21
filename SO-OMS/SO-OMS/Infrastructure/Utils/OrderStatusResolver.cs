using System.Collections.Generic;

namespace SO_OMS.Domain.Utils
{
    public static class OrderStatusResolver
    {
        private static readonly List<string> _statuses = new List<string>
        {
            "新規予約",
            "受注確定",
            "発送済み",
            "キャンセル"
        };

        public static IEnumerable<string> GetAll()
        {
            return _statuses;
        }
    }
}
