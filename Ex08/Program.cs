using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex08
{
    //第8条：用null条件运算符调用事件处理程序
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class EventSource
    {
        private EventHandler<int> Updated;

        public void RaiseUpdates()
        {
            counter++;
            //旧式委托调用的写法
            //var handler = Updated;
            //if (handler != null)
            //{
            //    handler(this, counter);
            //}

            //新式委托调用的写法
            Updated?.Invoke(this, counter);
            
        }

        private int counter;
    }
}
