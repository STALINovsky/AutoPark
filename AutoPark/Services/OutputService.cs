using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoPark
{
    public static class OutputService
    {
        public static void PrintCollection<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public static void PrintSameElements<T>(IEnumerable<T> elements)
        {
            var recurringItems = elements.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(y => new { Value = y.Key, Count = y.Count() });


            foreach (var recurringItem in recurringItems)
            {
                Console.WriteLine($"vehicle: {recurringItem.Value}, count: {recurringItem.Count}");
            }
        }
    }
}