using System.Collections.Generic;
using System.Linq;

namespace SO_OMS.Domain.Utils
{
    public static class CategoryResolver
    {
        private static readonly Dictionary<int, string> _idToName = new Dictionary<int, string>
        {
            { 1, "食品" },
            { 2, "雑貨" },
            { 3, "その他" }
        };

        private static readonly Dictionary<string, int> _nameToId = _idToName.ToDictionary(kv => kv.Value, kv => kv.Key);

        public static string GetName(int categoryId)
        {
            return _idToName.TryGetValue(categoryId, out var name) ? name : "その他";
        }

        public static int GetId(string categoryName)
        {
            return _nameToId.TryGetValue(categoryName, out var id) ? id : 3;
        }

        public static IEnumerable<KeyValuePair<int, string>> GetAll()
        {
            return _idToName;
        }
    }
}
