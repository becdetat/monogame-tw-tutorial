using System;
using System.Collections.Generic;
using System.Linq;

namespace Win8ShooterGame.Extensions
{
    public static class CollectionExtensions
    {
        public static void RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)
        {
            var toRemove = collection.Where(predicate).ToArray();

            foreach (var item in toRemove)
            {
                collection.Remove(item);
            }
        }
    }
}