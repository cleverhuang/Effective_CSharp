using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex34
{
    //第34条：考虑通过函数参数来放松耦合关系
    class Program
    {
        static void Main(string[] args)
        {
            //var first = new string[] { "One", "Two", "Three" };
            //var second = new string[] { "1", "2", "3" };
            //var result = Zip(first, second, (one, two) => string.Format("{0} {1}", one, two));

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}

            //var startAt = 0;
            //var nextValue = 3;

            //var sequence = CreateSequence(1000, () => startAt += nextValue);

            //foreach (var item in sequence)
            //{
            //    Console.WriteLine(item);
            //}

            var sequence = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var total = 0;
            total = Sum(sequence, total, (sum, num) => sum + num);
            Console.WriteLine(total);



        }

        public static IEnumerable<TResult> Zip<T1, T2, TResult>(IEnumerable<T1> first, IEnumerable<T2> second, Func<T1, T2, TResult> zipper)
        {
            using (var firstSequence = first.GetEnumerator())
            {
                using (var secondSequence = second.GetEnumerator())
                {
                    while (firstSequence.MoveNext() && secondSequence.MoveNext())
                    {
                        yield return zipper(firstSequence.Current, secondSequence.Current);
                    }
                }
            }
        }

        public static IEnumerable<T> CreateSequence<T>(int numberOfElements, Func<T> generator)
        {
            for (var i = 0; i < numberOfElements; i++)
            {
                yield return generator();
            }
        }

        public static T Sum<T>(IEnumerable<T> sequence, T total, Func<T, T, T> accumulator)
        {
            foreach (T item in sequence)
            {
                total = accumulator(total, item);
            }

            return total;
        }

        public static TResult Fold<T, TResult>(IEnumerable<T> sequence, TResult total, Func<T, TResult, TResult> accumulator)
        {
            foreach (T item in sequence)
            {
                total = accumulator(item, total);
            }

            return total;
        }
    }
}
