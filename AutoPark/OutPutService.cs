using System;
using System.Collections.Generic;

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


    }
}