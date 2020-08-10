using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex24
{
    //第24条：如果有泛型方法，就不要再创建针对基类或接口的重载版本
    class Program
    {
        static void WriteMessage(MyBase b)
        {
            Console.WriteLine("Inside writeMessage(MyBase)");
        }

        static void WriteMessage<T>(T obj)
        {
            Console.Write("Inside writemessage<T>(T): ");
            Console.WriteLine(obj.ToString());
        }
        static void WriteMessage(IMessageWriter obj)
        {
            Console.Write("Inside writemessage(IMessageWriter): ");
            obj.WriteMessage();
        }


        static void Main(string[] args)
        {
            MyDerived d = new MyDerived();
            Console.WriteLine("Call Program.WriteMessage");
            WriteMessage(d);
            Console.WriteLine();



            Console.WriteLine("Calling through IMessageWriter interface");
            WriteMessage((IMessageWriter)d);
            Console.WriteLine();


            Console.WriteLine("Cast to base object");
            WriteMessage((MyBase)d);
            Console.WriteLine();

            Console.WriteLine( "Another type test:");
            AnotherType anotherType = new AnotherType();
            WriteMessage(anotherType); 
            Console.WriteLine();

            Console.WriteLine("Cast to IMessageWriter:");
            WriteMessage((IMessageWriter)anotherType);
        }
    }

    public class MyBase
    {


    }

    public interface IMessageWriter
    {
        void WriteMessage();
    }

    public class MyDerived:MyBase,IMessageWriter
    {
        void IMessageWriter.WriteMessage() => Console.WriteLine("Inside MyDerived.WriteMessage");
    }

    public class AnotherType:IMessageWriter
    {
        public void WriteMessage() => Console.WriteLine("Inside AnotherType.WriteMessage");
    }
}
