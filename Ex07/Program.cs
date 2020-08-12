using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex07
{
    //第7条：用委托表示回调
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Enumerable.Range(1, 200).ToList();

            var oddNumbers = numbers.Find(n => n % 2 == 1);

            var test = numbers.TrueForAll(n => n < 50);

            Console.WriteLine(test);

            numbers.RemoveAll(n => n % 2 == 0);

            numbers.ForEach(item => Console.WriteLine(item));
        }
    }
}
