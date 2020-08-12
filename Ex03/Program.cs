using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    //第3条：优先考虑is或as运算符，尽量少用强制类型转换
    class Program
    {
        static void Main(string[] args)
        {
            //            object o = Factory.GetObject();

            //            //Version one:
            //            MyType t = o as MyType;
            //            if (t!=null)
            //            {
            ////work with t,It's a MyType
            //            }
            //            else
            //            {
            ////report the failure
            //            }

            //            //Version two
            //            try
            //            {
            //                MyType t;
            //                t = (MyType)o;
            //                if (t != null)
            //                {
            //                    //work with t,It's a MyType
            //                }
            //            }
            //            catch (InvalidCastException)
            //            {
            //                //report the conversion failure
            //            }

            var collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var small = from int item in collection
                        where item < 5
                        select item;

            var small2 = collection.Cast<int>().Where(item => item < 5).Select(n => n);

        }
    }

    public class SecondType
    {
        private MyType _value;

        public static implicit operator MyType(SecondType t)
        {
            return t._value;
        }
    }
}
