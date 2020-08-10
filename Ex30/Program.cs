using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex30
{
    //第30条：优先考虑通过查询语句来编写代码，而不要使用循环语句
    class Program
    {
        static void Main(string[] args)
        {
            //命令式写法
            //var foo = new int[100];

            //for (var num = 0; num < foo.Length; num++)
            //{
            //    foo[num] = num * num;
            //}

            //foreach (int i in foo)
            //{
            //    Console.WriteLine(i.ToString());
            //}

            //查询式语法
            //var foo = (from n in Enumerable.Range(0, 100)
            //           select n * n)
            //         .ToArray();
            //foo.ForAll((n) => Console.WriteLine(n.ToString()));


            var result1 = ProduceIndices();
            var result2 = QueryIndices();
            var result3 = MethodIndices3();

            foreach (var item in result1)
            {
                Console.WriteLine($" ({item.Item1},{item.Item2}) ");
            }
            Console.WriteLine();
            foreach (var item in result2)
            {
                Console.WriteLine($" ({item.Item1},{item.Item2}) ");
            }
            Console.WriteLine();
            foreach (var item in result3)
            {
                Console.WriteLine($" ({item.Item1},{item.Item2}) ");
            }
        }

        private static IEnumerable<Tuple<int, int>> ProduceIndices()
        {
            var storage = new List<Tuple<int, int>>();

            for (int x = 0; x < 100; x++)
            {
                for (int y = 0; y < 100; y++)
                {
                    if (x + y < 100)
                    {
                        storage.Add(Tuple.Create(x, y));
                    }
                }
            }

            storage.Sort((point1, point2) => (point2.Item1 * point2.Item1 + point2.Item2 * point2.Item2).CompareTo(point1.Item1 * point1.Item1 + point1.Item2 * point1.Item2));

            return storage;
        }

        private static IEnumerable<Tuple<int, int>> QueryIndices()
        {
            return from x in Enumerable.Range(0, 100)
                   from y in Enumerable.Range(0, 100)
                   where x + y < 100
                   orderby (x*x+y*y) descending
                   select Tuple.Create(x, y);
        }

        private static IEnumerable<Tuple<int, int>> MethodIndices3()
        {
            return Enumerable.Range(0, 100)
                .SelectMany(x => Enumerable.Range(0, 100), (x, y) => Tuple.Create(x, y)).Where(pt => pt.Item1 + pt.Item2 < 100)
                .OrderByDescending(pt => pt.Item1 * pt.Item1 + pt.Item2 * pt.Item2);
        }
    }

    public static class Extensions
    {
        public static void ForAll<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T item in sequence)
            {
                action(item);
            }
        }
    }
}
