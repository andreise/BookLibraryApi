using Common.Diagnostics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Linq
{
    public static class EnumerableExtensions
    {
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            Contract.RequiresArgumentNotNull(source, nameof(source));
            Contract.RequiresArgumentNotNull(action, nameof(action));

            foreach (var item in source)
            {
                action(item);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)
        {
            Contract.RequiresArgumentNotNull(source, nameof(source));
            Contract.RequiresArgumentNotNull(action, nameof(action));

            int index = -1;
            foreach (var item in source)
            {
                checked { ++index; }
                action(item, index);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, long> action)
        {
            Contract.RequiresArgumentNotNull(source, nameof(source));
            Contract.RequiresArgumentNotNull(action, nameof(action));

            long index = -1;
            foreach (var item in source)
            {
                checked { ++index; }
                action(item, index);
            }
        }

        public static IEnumerable<TSource> Yield<TSource>(this TSource source)
        {
            yield return source;
        }

        public static IEnumerable<TSource> Concat<TSource>(this TSource first, IEnumerable<TSource> second)
        {
            Contract.RequiresArgumentNotNull(second, nameof(second));

            return first.Yield().Concat(second);
        }

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, TSource second)
        {
            Contract.RequiresArgumentNotNull(first, nameof(first));

            return first.Concat(second.Yield());
        }

        public static bool IsNullOrEmpty<TSource>(this IReadOnlyCollection<TSource> collection) =>
            collection is null || collection.Count == 0;

        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> collection) =>
            collection is null || !collection.Any();

        public static bool IsIn<TSource>(this TSource source, IEnumerable<TSource> collection)
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source);
        }

        public static bool IsIn<TSource>(this TSource source, IEnumerable<TSource?> collection) where TSource : struct
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source);
        }

        public static bool IsIn<TSource>(this TSource source, params TSource[] collection)
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source);
        }

        public static bool IsIn<TSource>(this TSource source, params TSource?[] collection) where TSource : struct
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source);
        }

        public static bool IsIn<TSource>(this TSource source, IEqualityComparer<TSource> comparer, IEnumerable<TSource> collection)
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source, comparer);
        }

        public static bool IsIn<TSource>(this TSource source, IEqualityComparer<TSource?> comparer, IEnumerable<TSource?> collection) where TSource : struct
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source, comparer);
        }

        public static bool IsIn<TSource>(this TSource source, IEqualityComparer<TSource> comparer, params TSource[] collection)
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source, comparer);
        }

        public static bool IsIn<TSource>(this TSource source, IEqualityComparer<TSource?> comparer, params TSource?[] collection) where TSource : struct
        {
            Contract.RequiresArgumentNotNull(collection, nameof(collection));

            return collection.Contains(source, comparer);
        }
    }
}
