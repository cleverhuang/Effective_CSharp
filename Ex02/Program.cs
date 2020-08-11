using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    //第2条：考虑用readonly代替const
    class Program
    {
        //Compile-time constant
        public const int Millennium = 2000;

        //Runtime constant
        public static readonly int ThisYear = 2020;

        static void Main(string[] args)
        {
            for (int i = UsefulValues.startValue; i < UsefulValues.EndValue; i++)
            {
                Console.WriteLine($"Value is {i}");
            }
        }
    }

    public class UsefulValues
    {
        public static readonly int startValue = 105;
        public static int EndValue = 120;
    }

    public class RevisionInfo
    {
        public static string RevisionString = "1.1.R9";
        public const string RevisionMessage = "Update Fall 2015";
    }
}
