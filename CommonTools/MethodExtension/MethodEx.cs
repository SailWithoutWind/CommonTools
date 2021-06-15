using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonTools
{
    public static class MethodEx
    {
        /// <summary>
        /// 交换元素位置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="CurrentCount"></param>
        /// <param name="PreviousOneIndex"></param>
        public static void ExChangeIndex<T>(this IList<T> list, int CurrentCount, int PreviousOneIndex)
        {
            var ListTemp = list[CurrentCount];
            list[CurrentCount] = list[PreviousOneIndex];
            list[PreviousOneIndex] = ListTemp;
        }
        public static double ToDouble(this string str)
        {
            try
            {
                return Convert.ToDouble(str);
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public static IEnumerable<T> DistinctObject<T, TResult>(this IEnumerable<T> source, Func<T, TResult> selector)
        {
            var hs = new HashSet<TResult>();
            foreach (T item in source)
            {
                var result = selector(item);
                var isSuccess = hs.Add(result);
                if (isSuccess)
                {
                    yield return item;
                }
            }
        }
    }
}
