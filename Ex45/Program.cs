using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex45
{
    //第45条：考虑在方法约定遭到违背时抛出异常
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class DoesWorkThatMightFail
    {
        public bool TryDoWork()
        {
            if (!TestConditions())
            {
                return false;
            }
            Work();
            return true;
        }

        public void DoWork()
        {
            Work();
        }

        private bool TestConditions()
        {
            return true;
        }

        private void Work()
        {
            
        }
    }
}
