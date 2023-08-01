using System.Collections.Generic;
using System.Linq;

namespace NeilvynSampleBlueprint.Mobile.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsEmptyOrNull<T>(this IEnumerable<T> items)
        {
            return items == null || !items.Any();
        }

        public static bool IsNotEmpty<T>(this IEnumerable<T> items)
        {
            return items != null && items.Any();
        }

        public static IEnumerable<T> ToNonNull<T>(this IEnumerable<T> items)
        {
            return items ?? Enumerable.Empty<T>();
        }

        public static IList<T> ToNonNullableList<T>(this IEnumerable<T> items)
        {
            return items?.ToList() ?? new List<T>();
        }

        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> list)
        {
            if (list == null)
            {
                return;
            }

            foreach(var i in list)
            {
                collection?.Add(i);
            }
        }

    }
}
