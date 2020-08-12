using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex09
{
    //第9条：尽量避免装箱与取消装箱这两种操作
    class Program
    {
        static void Main(string[] args)
        {
            //object firstParm = 5;
            //object o = firstParm;
            //int i = (int)o;//unbox
            //string output = i.ToString();

            var attendees = new List<Person>();
            Person p = new Person { Name = "Old Name" };
            attendees.Add(p);

            Person p2 = attendees[0];
            p2.Name = "New Name";

            Console.WriteLine(attendees[0].ToString());

            Console.WriteLine(p2.ToString());

        }
    }

    public struct Person
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
