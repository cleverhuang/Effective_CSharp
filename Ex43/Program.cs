using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex43
{
    //第43条：用Single（）及First（）来明确地验证你对查询结果所做的假设
    class Program
    {
        static void Main(string[] args)
        {
            var somePeople = new List<Person> {
            new Person{ FirstName="Bill",LastName="Gates"},
            new Person{ FirstName="Bill",LastName="Wagner"},
            new Person{ FirstName="Bill",LastName="Johnson"},
            };

            var answer = (from p in somePeople
                          where p.FirstName == "Bill"
                          select p).SingleOrDefault();

            Console.WriteLine(answer?.FirstName);
        }
    }
}
