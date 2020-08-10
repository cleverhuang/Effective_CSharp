using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex29
{
    //第29条：优先考虑提供迭代器方法，而不要返回集合
    class Program
    {
        static void Main(string[] args)
        {
            //ar allNumbers = Enumerable.Range(0, int.MaxValue);

            var a_z = GenerateAlphabet();
            foreach (var item in a_z)
            {
                Console.Write($"{item},");
            }
            Console.WriteLine();
            var xToz = GenerateAlphabetSubset('x', 'z');
            foreach (var item in xToz)
            {
                Console.Write($"{item},");
            }
        }

        public static IEnumerable<char> GenerateAlphabet()
        {
            var letter = 'a';
            while (letter <= 'z')
            {
                yield return letter;
                letter++;
            }
        }


        public static IEnumerable<char> GenerateAlphabetSubset(char first, char last)
        {
            if (first < 'a')
            {
                throw new ArgumentException("first must be at least the letter a", nameof(first));
            }
            if (first > 'z')
            {
                throw new ArgumentException("first must be no greater than z", nameof(first));
            }
            if (last < first)
            {
                throw new ArgumentException("last must be at least as larger as first", nameof(last));
            }
            if (last > 'z')
            {
                throw new ArgumentException("last must not be past z", nameof(last));
            }

            return GenerateAlphabetSubsetImpl(first, last);
        }

        private static IEnumerable<char> GenerateAlphabetSubsetImpl(char first,char last)
        {
            var letter = first;
            while (letter<=last)
            {
                yield return letter;
                letter++;
            }
        }
    }
}
