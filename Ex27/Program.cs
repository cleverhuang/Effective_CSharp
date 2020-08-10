using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex27
{
    //第27条：只把必备的契约定义在接口中，把其他功能留给扩展方法去实现
    class Program
    {
        static void Main(string[] args)
        {
            MyType t = new MyType();
            UpdateMarker(t);

            System.Console.WriteLine(t.Marker);
        }

        public static void UpdateMarker(MyType foo)
        {
            foo.NextMarker();
        }
    }

    //MyType version 2
    public class MyType:IFoo
    {
        public int Marker { get; set; }
        public void NextMarker() => Marker += 5;
    }

    //MyType version 1
    //public class MyType : IFoo
    //{
    //    public int Marker { get; set; }
    //}

    public interface IFoo
    {
        int Marker { get; set; }
    }

    public static class FooExtensions
    {
        public static void NextMarker(this IFoo thing)
        {
            thing.Marker += 1;
        }
    }
}
