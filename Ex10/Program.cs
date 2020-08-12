using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex10
{
    //第10条：只有在应对新版基类与现有子类之间的冲突时才应该使用new修饰符
    class Program
    {
        static void Main(string[] args)
        {
            //object c = MakeObject();

            object c = new MyOtherClass();

            MyClass c1 = c as MyClass;
            c1.MagicMethod();

            MyOtherClass c2 = c as MyOtherClass;
            c2.MagicMethod();
        }
    }

    public class MyClass
    {
        public void MagicMethod()
        {
            Console.WriteLine("MyClass");
        }
    }

    public class MyOtherClass:MyClass
    {
        public new void MagicMethod()
        {
            Console.WriteLine("MyOtherClass");
        }
    }

    public class MyWidget:BaseWidget
    {
        public new void NormalizeValues()
        {
            base.NormalizeValues();   
        }
    }
}
