using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    //第1条：优先使用隐式类型的局部变量
    class Program
    {
        static void Main(string[] args)
        {
            var f = GetMagicNumber();

            var total = 100 * f / 6;

            Console.WriteLine($"Declared Type:{total.GetType().Name},Value:{total}");
        }

        private static double GetMagicNumber()
        {
            return 100.0;
        }
    }
}
