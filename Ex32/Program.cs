using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex32
{
    //第32条：将迭代逻辑与操作、谓词及函数解耦
    class Program
    {
        static void Main(string[] args)
        {
            int[] myInts = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //foreach (int i in Transform(myInts, value => value * value))
            //{
            //    Console.WriteLine(i);
            //}

            foreach (string s in Transform(myInts, value => (value*value).ToString()))
            {
                Console.WriteLine(s);
            }
        }

        public static IEnumerable<T> Where<T>(IEnumerable<T> sequence, Predicate<T> filterFunc)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence), "sequence must not be null");
            }

            if (filterFunc == null)
            {
                throw new ArgumentNullException("Predicate must not be null");
            }

            foreach (T item in sequence)
            {
                if (filterFunc(item
                    ))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> EveryNthItem<T>(IEnumerable<T> sequence, int period)
        {
            var count = 0;
            foreach (T item in sequence)
            {
                if (++count % period == 0)
                {
                    yield return item;
                }
            }
        }

        //public static IEnumerable<T> Transform<T>(IEnumerable<T> sequence, Func<T, T> method)
        //{
        //    foreach (T element in sequence)
        //    {
        //        yield return method(element);
        //    }
        //}

        public static IEnumerable<Tout> Transform<Tin, Tout>(IEnumerable<Tin> sequence, Func<Tin, Tout> method)
        {
            foreach (Tin element in sequence)
            {
                yield return method(element);
            }
        }
    }
}
