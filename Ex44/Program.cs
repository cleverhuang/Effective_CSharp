using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex44
{
    //第44条：不要修改绑定变量
    class Program
    {
        static void Main(string[] args)
        {

            int[] someNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //var answer = from n in someNumbers
            //             select n * n;

            ModFilter m = new ModFilter(3);
             
            var values = m.FindValues(someNumbers);
            foreach (var item in values)
            {
                Console.WriteLine(item);
            }








            //var index = 0;
            //Func<IEnumerable<int>> sequence = () => Utilities.Generate(30, index++);

            //index = 20;
            //foreach (int n in sequence)
            //{
            //    Console.WriteLine(n);
            //}

            //index = 100;
            //foreach (int n in sequence)
            //{
            //    Console.WriteLine(n);
            //}

        }
    }

    public class ModFilter
    {
        private readonly int modulus;
        public ModFilter(int mod)
        {
            modulus = mod;
        }

        public IEnumerable<int> FindValues(IEnumerable<int> sequence)
        {
            int numValues = 0;
            return from n in sequence
                   where n % modulus == 0
                   select (n * n) / (++numValues);
        }
    }
}
