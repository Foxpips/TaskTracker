using System;
using System.Collections.Generic;

namespace TaskTracker.Helpers
{
    public static class Extensions
    {
        public static void ForEach<TItem>(this IEnumerable<TItem> enumerable, Action<TItem> work)
        {
            foreach (var item in enumerable)
            {
                work(item);
            }
        }
    }
}