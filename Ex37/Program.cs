using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex37
{
    //第37条：尽量采用惰性求值的方式来查询，而不要及早求值
    class Program
    {
        static void Main(string[] args)
        {

            //var answers = from number in AllNumbers()
            //              select number;

            //var smallNumbers = answers.Take(10);

            //foreach (var num in smallNumbers)
            //{
            //    Console.WriteLine(num);
            //}



            //LazyEvaluation();

            //var sequence1 = Generate(10, () => DateTime.Now);
            //var sequence2 = from value in sequence1
            //                select value.ToUniversalTime();
            //foreach (var item in sequence2)
            //{
            //    Console.WriteLine(item);
            //}
        }

        static IEnumerable<int> AllNumbers()
        {
            var number = 0;
            while (number < int.MaxValue)
            {
                yield return number++;
            }
        }

        private static IEnumerable<TResult> Generate<TResult>(int number, Func<TResult> generator)
        {
            for (int i = 0; i < number; i++)
            {
                yield return generator();
            }
        }

        private static void LazyEvaluation()
        {
            Console.WriteLine($"Start time for Test One:{DateTime.Now:T}");
            var sequence = Generate(10, () => DateTime.Now);

            Console.WriteLine("Waiting....\tPress Return");
            Console.ReadLine();

            Console.WriteLine("Iterating...");
            foreach (var value in sequence)
            {
                Console.WriteLine($"{value:T}");
            }

            Console.WriteLine("Waiting....\tPress Return");
            Console.ReadLine();

            Console.WriteLine("Iterating...");
            foreach (var value in sequence)
            {
                Console.WriteLine($"{value:T}");
            }
        }
    }
}
