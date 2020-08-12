using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex13
{
    //第13条：用适当的方式初始化类中的静态成员
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class MySingleton2
    {
        private static readonly MySingleton2 theOneOnly;

        static MySingleton2()
        {
            theOneOnly = new MySingleton2();
        }

        private MySingleton2()
        { }
    }

    public class MySingleton
    {
        private static readonly MySingleton theOneAndOnly = new MySingleton();

        public static MySingleton TheOnly
        {
            get { return theOneAndOnly; }
        }

        private MySingleton()
        {

        }
    }
}
