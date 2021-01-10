using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPark.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsIndexValid<T>(this IEnumerable<T> enumerable, int index)
        {
            var count = enumerable.Count();
            return index < count && index > -1;
        }

        public static T SelectMax<T,TCompare>(this IEnumerable<T> source,Func<T,TCompare> func) where TCompare : IComparable<TCompare>
        {
            T max = default;
            TCompare maxValue = default;
            foreach (var item in source)
            {
                TCompare itemValue = func(item);
                if (itemValue.CompareTo(maxValue) > 0)
                {
                    max = item;
                    maxValue = itemValue;
                }
            }

            return max;
        }

        public static T SelectMin<T, TCompare>(this IEnumerable<T> source, Func<T, TCompare> func) where TCompare : IComparable<TCompare>
        {
            T min = default;
            TCompare maxValue = default;
            foreach (var item in source)
            {
                TCompare itemValue = func(item);
                if (itemValue.CompareTo(maxValue) < 0)
                {
                    min = item;
                    maxValue = itemValue;
                }
            }

            return min;
        }
    }
}