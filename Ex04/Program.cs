using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04
{
    //第4条：用内插字符串取代string.Format（）
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"The value of pi is {Math.PI}");

            //Console.WriteLine($"The value of pi is {Math.PI.ToString()}");

            //Console.WriteLine($"The value of pi is {Math.PI.ToString("F2")}");
            //Console.WriteLine($"The value of pi is {Math.PI:F2}");

            //bool round = true;

            //Console.WriteLine($@"The value of pi is {(round?Math.PI.ToString():Math.PI.ToString("F2"))}");

            //Customer c = new Customer("Clever");
            //Customer c = new Customer();
            //Customer c = null;

            //Console.WriteLine($"The customer's name is {c?.Name??"Name is missing"}");

            //string result = default(string);
            //Console.WriteLine($@"Record is {(records.TryGetValue(index,out result)?result:$"No record found at index {index}")}");

            var src = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var output = $@"The First five items are:{src.Take(5).Select(n => $@"Item: {n.ToString()}").Aggregate((c, a) => $@"{c}{Environment.NewLine}{a}")}";

            Console.WriteLine(output);
        }
    }
}
