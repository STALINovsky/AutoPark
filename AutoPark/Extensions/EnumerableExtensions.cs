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

        //algorithms based on Microsoft implementation https://github.com/dotnet/runtime/blob/master/src/libraries/System.Linq/src/System/Linq/Max.cs\
        /// <summary>
        /// Iterates over the elements of the collection and selects the element by selector and comparer 
        /// </summary>
        /// <typeparam name="TSource">Source sequence of items</typeparam>
        /// <typeparam name="TCompare">The type used to compare elements</typeparam>
        /// <param name="source">Source sequence of elements</param>
        /// <param name="selector">Func that return value to compare</param>
        /// <param name="comparer">Func that compare two items (searchedItemValue, candidateValue) if return true then searchedItem = candidate</param>
        /// <returns></returns>
        private static TSource SelectItemBy<TSource, TCompare>
            (IEnumerable<TSource> source, Func<TSource, TCompare> selector, Func<TCompare, TCompare, bool> comparer)
        {
            //checking for null
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));

            //select first item, if collection is empty throw InvalidOperationException
            using var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("Source collection is empty");
            }

            //make an assumption about the desired element
            var searchedItem = enumerator.Current;
            var searchedItemValue = selector(enumerator.Current);

            //iterate over the collection and select searchedItem item
            while (enumerator.MoveNext())
            {
                var candidate = enumerator.Current;
                var candidateValue = selector(candidate);
                // if comparer return true then searchedItem = candidate 
                if (comparer(searchedItemValue, candidateValue))
                {
                    searchedItem = candidate;
                    searchedItemValue = candidateValue;
                }
            }

            return searchedItem;
        }

        /// <summary>
        /// finds the max element by value returned selector 
        /// </summary>
        /// <typeparam name="TSource">Type of item</typeparam>
        /// <typeparam name="TCompare">the type on which the comparison of elements is based</typeparam>
        /// <param name="source">Source sequence of elements</param>
        /// <param name="selector">function that takes an element and returns a value for comparing items</param>
        /// <returns></returns>
        public static TSource SelectMax<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> selector)
            where TCompare : IComparable<TCompare>
        {
            //delegate to SelectItemBy and define comparer as searchedItem < candidate
            return SelectItemBy(source, selector, (searchedItem, candidate) => searchedItem.CompareTo(candidate) < 0);
        }

        /// <summary>
        /// finds the min element by value returned selector 
        /// </summary>
        /// <typeparam name="TSource">Type of item</typeparam>
        /// <typeparam name="TCompare">the type on which the comparison of elements is based</typeparam>
        /// <param name="source">Source sequence of elements</param>
        /// <param name="selector">function that takes an element and returns a value for comparing items</param>
        /// <returns></returns>
        public static TSource SelectMin<TSource, TCompare>(this IEnumerable<TSource> source, Func<TSource, TCompare> selector)
            where TCompare : IComparable<TCompare>
        {
            //delegate to SelectItemBy and define comparer as searchedItem > candidate
            return SelectItemBy(source, selector, (searchedItem, candidate) => searchedItem.CompareTo(candidate) > 0);
        }


    }
}