using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex36
{
    //第36条：理解查询表达式与方法调用之间的映射关系
    class Program
    {
        static void Main(string[] args)
        {
            //Join GroupJoin
            //表达式中含有into子句 就转为 GroupJoin
            //表达式中不含有into子句 就转为 Join
            var numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var labels = new string[] { "0", "1", "2", "3", "4", "5", };

            //不带into的Join表达式
            //var query = from num in numbers
            //            join label in labels on num.ToString() equals label
            //            select new { num, label };

            //等价于
            //var query = numbers.Join(labels, num => num.ToString(), label => label, (num, label) => new { num, label });
            //foreach (var item in query)
            //{
            //    Console.WriteLine(item);
            //}


            ////带有Into子句的
            //var groups = from p in projects
            //             join t in tasks on p equals t.Parent
            //             into projTasks
            //             select new { Project = p, projTasks };

            ////等价于
            //var group = projects.GroupJoin(tasks, p => p, t => t.Parent, (p, t) => new { Project = p, TaskList = projTasks });





            //SelectMany 
            //int[] odds = { 1, 3, 5, 7 };
            //int[] evens = { 2, 4, 6, 8 };

            //var values = from oddNumber in odds
            //             from evenNumber in evens
            //             where oddNumber > evenNumber
            //             select new
            //             {
            //                 oddNumber,
            //                 evenNumber,
            //                 Sum = oddNumber + evenNumber,
            //             };

            ////等价于
            //var values1 = odds.SelectMany(oddNumber => evens,
            //    (oddNumber, evenNumber) => new { oddNumber, evenNumber })
            //    .Where(pair => pair.oddNumber > pair.evenNumber)
            //    .Select(pair => new
            //    {
            //        pair.oddNumber,
            //        pair.evenNumber,
            //        Sum = pair.oddNumber + pair.evenNumber
            //    });

            //foreach (var item in values1)
            //{
            //    Console.WriteLine($"{item.oddNumber},{item.evenNumber},{item.Sum}");
            //}

            //var triples = from n in new int[] { 1, 2, 3 }
            //              from s in new string[] { "One", "Two", "Three" }
            //              from r in new string[] { "I", "II", "III" }
            //              select new { Arabic = n, Word = s, Roman = r };

            //等价于
            //var numbers = new int[] { 1, 2, 3 };
            //var words = new string[] { "One", "Two", "Three" };
            //var romanNumberals = new string[] { "I", "II", "III" };
            //var triples = numbers.SelectMany(n => words, (n, s) => new { n, s })
            //    .SelectMany(pair => romanNumberals, (pair, r) => new { Arabic = pair.n, Word = pair.s, Roman = r });

            //foreach (var item in triples)
            //{
            //    Console.WriteLine(item);
            //}


            //int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //var smallNumbers = from n in numbers
            //                   where n < 5
            //                   select n;

            //var smallNumbers2 = numbers.Where(n => n < 5);

            //var smallNumbers3 = from n in numbers
            //                    where n < 5
            //                    select n * n;

            //var sequares = from n in numbers
            //               select new { Number = n, Square = n * n };

            //var sequares = numbers.Select(n => new { Number = n, Square = n * n });

            //foreach (var item in sequares)
            //{
            //    Console.WriteLine(item);
            //}


            //var people = from e in employees
            //             where e.Age > 30
            //             orderby e.LastName, e.FirstName, e.Age
            //             select e;

            //var people = employees.Where(e => e.Age > 30).OrderBy(e => e.LastName).ThenBy(e => e.FirstName).ThenBy(e => e.Age);

            // var employees = new List<Person> {
            //     new Person{ FirstName="George", LastName="Washington",Age=18,Department="ME"},
            //     new Person{FirstName="Thomas",LastName="Jefferson",Age=20,Department="QC"},
            //     new Person{FirstName="Abe",LastName="Lincoln",Age=23,Department="IE"}
            //};

            //var results = from e in employees
            //              group e by e.Department into d
            //              select new
            //              {
            //                  Department = d.Key,
            //                  Size = d.Count()
            //              };
            //上下等价于
            //var results = employees.GroupBy(e => e.Department).Select(d => new { Department = d.Key, Size = d.Count() });



            //var results = from e in employees
            //              group e by e.Department into d
            //              select new
            //              {
            //                  Department = d.Key,
            //                  Employees = d.AsEnumerable()
            //              };
            ////上下等价
            //var result2 = employees.GroupBy(e => e.Department)
            //    .Select(d => new
            //    {
            //        Department = d.Key,
            //        Employees = d.AsEnumerable()
            //    });
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Department { get; set; }

    }
}

