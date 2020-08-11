using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex46
{
    //第46条：利用using与try/finally来清理资源
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader s1=new StreamReader("1.txt"))
            {

            }
            //or
            StreamReader s2 = null;
            try
            {
                s2 = new StreamReader("2.txt");
            }
            finally
            {
                s2.Dispose();
            }
        }
    }
}
