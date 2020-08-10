using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Ex35
{
    //第35条：绝对不要重载扩展方法
    class Program
    {
        static void Main(string[] args)
        {

            List<Person> somePresidents = new List<Person> {
            new Person{ FirstName="George",
            LastName="Washington"},
            new Person{
            FirstName="Thomas",
            LastName="Jefferson"},
            new Person{
            FirstName="Abe",
            LastName="Lincoln"
            },
            };

            //foreach (Person person in somePresidents)
            //{
            //    Console.WriteLine(person.Format());
            //}

            foreach (Person p in somePresidents)
            {
                Console.WriteLine(PersonReports.FormatAsText(p));
                Console.WriteLine();
                Console.WriteLine(PersonReports.FormatAsXML(p));

            }
        }


    }

    public sealed class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class ConsoleReport
    {
        public static string Format(this Person target) => $"{target.LastName,20},{target.FirstName,15}";
    }


    public static class PersonReports
    {
        public static string FormatAsText(Person target) => $"{target.LastName,20},{target.FirstName,15}";

        public static string FormatAsXML(Person target) => new XElement("Person",
            new XElement("LastName", target.LastName),
            new XElement("FirstName", target.FirstName)
            ).ToString();
    }
}
