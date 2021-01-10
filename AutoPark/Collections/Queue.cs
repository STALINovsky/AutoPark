using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Collections
{
    /// <summary>
    /// Queue implements the principle FIFO(first in first out)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Queue<T>
    {
        private readonly List<T> dataList = new List<T>();
        /// <summary>
        /// Append item to the collection
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            dataList.Add(item);
        }

        /// <summary>
        /// delete and return first item from collection
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var lastElement = dataList[Length - 1];
            dataList.RemoveAt(dataList.Count - 1);

            return lastElement;
        }

        public int Length => dataList.Count;
    }
}
