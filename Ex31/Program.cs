using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex31
{
    //第31条：把针对序列的API设计得更加易于拼接
    class Program
    {
        static void Main(string[] args)
        {
            //var nums = new int[] { 0, 3, 2, 1, 4, 5, 6, 7, 8, 9, 5, 2, 4, 6, 3, 1, 0, 7 };

            //var unqiues = UniqueV3<int>(nums);
            //Console.WriteLine();
            //foreach (var item in Square(unqiues))
            //{
            //    Console.WriteLine(item);
            //}

            var str1 = new string[] { "One", "Two", "Three" };
            var str2 = new string[] { "1", "2", "3" };

            var result = Zip(str2, str1);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }

        }

        public static void Unique(IEnumerable<int> nums)
        {
            var uniqueVals = new HashSet<int>();

            foreach (var num in nums)
            {
                if (!uniqueVals.Contains(num))
                {
                    uniqueVals.Add(num);
                    WriteLine(num);
                }
            }
        }

        public static IEnumerable<int> UniqueV2(IEnumerable<int> nums)
        {
            var uniqueVals = new HashSet<int>();
            WriteLine("\tEntering Unique");
            foreach (var num in nums)
            {
                WriteLine("\tEvaluating {0}", num);
                if (!uniqueVals.Contains(num))
                {
                    WriteLine("\tAdding {0}", num);
                    uniqueVals.Add(num);
                    yield return num;
                    WriteLine("\tRe-entering after yield return");
                }
            }

            WriteLine("\tExiting Unique ");
        }

        public static IEnumerable<T> UniqueV3<T>(IEnumerable<T> sequence)
        {
            var uniqueVals = new HashSet<T>();

            foreach (T item in sequence)
            {
                if (!uniqueVals.Contains(item))
                {
                    uniqueVals.Add(item);
                    yield return item;
                }
            }
        }

        public static IEnumerable<int> Square(IEnumerable<int> nums)
        {
            foreach (var num in nums)
            {
                yield return num * num;
            }
        }

        public static IEnumerable<string> Zip(IEnumerable<string> first, IEnumerable<string> second)
        {
            using (var firstSequence = first.GetEnumerator())
            {
                using (var secondSequence = second.GetEnumerator())
                {
                    while (firstSequence.MoveNext() && secondSequence.MoveNext())
                    {
                        yield return string.Format("{0} {1}", firstSequence.Current, secondSequence.Current);
                    }
                }
            }
        }
    }
}
