using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Ex41
{
    //第41条：不要把开销较大的资源捕获到闭包中
    class Program
    {
        static void Main(string[] args)
        {
            //var t = new StreamReader(File.OpenRead("TestFile.txt"));

            //var arrayOfNumbers = ReadNumbersFromStream(t);



            //using (TextReader t = new StreamReader(File.OpenRead("../../TestFile.txt")))
            //{
            //    var arrayOfNums = ReadNumbersFromStream(t);

            //    foreach (var line in arrayOfNums)
            //    {
            //        foreach (int num in line)
            //        {
            //            Console.Write("{0}, ", num);
            //        }
            //        Console.WriteLine();
            //    }
            //}

            //var query = (from n in SomeFunction()
            //             select n).Take(5);

            //foreach (var s in query)
            //{
            //    Console.WriteLine(s);
            //}

            //Console.WriteLine("Again");
            //foreach (var s in query)
            //{
            //    Console.WriteLine(s);
            //}


            //var maximum = ProcessFile("../../TestFile.txt", (arrayOfNums) => (from line in arrayOfNums
            //                                                                  select line.Max()).Max());


            //Console.WriteLine(maximum);



        }

        //Method that reads files,processing each line using the delegate
        public static TResult ProcessFile<TResult>(string filePath, ProcessElementsFromFile<TResult> action)
        {
            using (TextReader t = new StreamReader(File.Open(filePath, FileMode.Open)))
            {
                var allLines = from line in t.ReadLines()
                               select line.Split(',');

                var matrixOfValues = from line in allLines
                                     select from item in line
                                            select item.DefaultParse(0);

                return action(matrixOfValues);
            }
        }


        public static IEnumerable<string> ParseFile(string path)
        {
            using (var r = new StreamReader(File.OpenRead(path)))
            {
                var line = r.ReadLine();
                while (line != null)
                {
                    yield return line;
                    line = r.ReadLine();
                }
            }
        }

        public static IEnumerable<IEnumerable<int>> ReadNumbersFromStream(TextReader t)
        {
            var allLines = from line in t.ReadLines()
                           select line.Split(',');
            var matrixOfValue = from line in allLines
                                select from item in line
                                       select item.DefaultParse(0);
            return matrixOfValue;

        }
    }


    //declare a delegate type
    public delegate TResult ProcessElementsFromFile<TResult>(IEnumerable<IEnumerable<int>> values);

    public class Generator : IDisposable
    {
        private int count;
        public int GetNextNumber() => count++;

        public void Dispose()
        {
            Console.WriteLine("Disposing now ");
        }
    }
    //public class Closure
    //{
    //    public int generatedCounter;
    //    public int generatorFunc() => generatedCounter++;
    //}

    public static class Extensions
    {
        public static IEnumerable<string> ReadLines(this TextReader reader)
        {
            var txt = reader.ReadLine();
            while (txt != null)
            {
                yield return txt;
                txt = reader.ReadLine();
            }
        }

        public static int DefaultParse(this string input, int defaultValue)
        {
            int answer;
            return (int.TryParse(input, out answer)) ? answer : defaultValue;
        }


    }
}
