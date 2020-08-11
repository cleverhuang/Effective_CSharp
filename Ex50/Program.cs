using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex50
{
    //第50条：合理利用异常筛选器的副作用来实现某些效果
    class Program
    {
        static void Main(string[] args)
        {
            int failure = 0;
            try
            {
                var data = MakeWebRequest();
            }
            catch (Exception e) when (ConsoleLogException(e)) { }
            catch (TimeoutException e) when ((failure++ < 10) && (!System.Diagnostics.Debugger.IsAttached))
            {

                Console.WriteLine("Timeout error:tryubf again");
            }
        }

        private static object MakeWebRequest()
        {
            throw new NotImplementedException();
        }

        public static bool ConsoleLogException(Exception e)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error:{0}", e);

            Console.ForegroundColor = oldColor;
            return false;
        }
    }
}
