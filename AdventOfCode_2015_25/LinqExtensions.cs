using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_2015_25
{
    public static class LinqExtensions
    {
        public static IEnumerable<TSource> MaxBy<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
            where TResult : IComparable<TResult>
        {
            var maxValue = source.Max(selector);
            return source.Where(i => selector(i).CompareTo(maxValue) == 0);
        }
    }
}
