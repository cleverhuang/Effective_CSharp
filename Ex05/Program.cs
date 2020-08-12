using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ex05
{
    //第5条：用FormattableString取代专门为特定区域而写的字符串
    class Program
    {
        static void Main(string[] args)
        {
            //string first = $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";
            //Console.WriteLine(first);

            //FormattableString second= $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";
            //Console.WriteLine(second);

            //var third= $"It's the {DateTime.Now.Day} of the {DateTime.Now.Month} month";

        }

        public static string ToGerman(FormattableString src)
        {
            return string.Format(
                null,
                CultureInfo.CreateSpecificCulture("de-de"), 
                src.Format, 
                src.GetArguments());
        }

        public static string ToFrenchCandada(FormattableString src)
        {
            return string.Format(null,
                CultureInfo.CreateSpecificCulture("fr-CA"),
                src.Format,
                src.GetArguments());
        }
    }
}
