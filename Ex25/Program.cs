using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex25
{
    //第25条：如果不需要把类型参数所表示的对象设为实例字段，那么应该优先考虑创建泛型方法，而不是泛型类
    class Program
    {
        static void Main(string[] args)
        {
            //double d1 = 4;
            //double d2 = 5;
            //double max = Utils.Max(d1, d2);

            //Console.WriteLine(max);

            CommaSeparatedListBuilder comma = new CommaSeparatedListBuilder();
            comma.Add("Hello");
            comma.Add("World");
            comma.Add("1");
            comma.Add("2");
            comma.Add("3");

            Console.WriteLine(comma.ToString());
        }
    }

    public class CommaSeparatedListBuilder
    {
        private StringBuilder storage = new StringBuilder();
        public void Add<T>(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                if (storage.Length > 0)
                {
                    storage.Append(",");
                }
                storage.Append("\"");
                storage.Append(item.ToString());
                storage.Append("\"");
            }
        }

        public override string ToString()
        {
            return storage.ToString();
        }
    }
}
