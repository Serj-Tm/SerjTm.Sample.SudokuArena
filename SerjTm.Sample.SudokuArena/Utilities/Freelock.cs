using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SerjTm.Sample.SudokuArena.Utilities
{
    public static class Freelock
    {
        public static (T, TResult) Exchange<T, TResult>(ref T item, Func<T, (T, TResult)> f) where T : class
        {
            for (; ; )
            {
                var currentItem = item;
                var (newItem, result) = f(currentItem);
                if (Interlocked.Exchange(ref item, newItem) == currentItem)
                    return (item, result);
            }
        }
    }
}
