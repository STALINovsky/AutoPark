using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPark.Collections
{
    /// <summary>
    /// Stack implements the principle FILO(first in last out)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Stack<T>
    {
        private readonly List<T> dataList = new List<T>();

        public void Push(T item)
        {
            dataList.Add(item);
        }

        public T Pop()
        {
            var first = dataList[0];
            dataList.RemoveAt(0);

            return first;
        }

        public int Length => dataList.Count;
    }
}
