using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex23
{
    //第23条：用委托要求类型参数必须提供某种方法
    class Program
    {
        static void Main(string[] args)
        {
            //int a = 6;
            //int b = 7;
            //int sum = Example.Add(a, b, (x, y) => x + y);

            //Console.WriteLine(sum);

            //double[] xValues = { 0,1,2,3,4,5,6,7,8,9,
            //0,1,2,3,4,5,6,7,8,9};
            //double[] yValues = { 0,1,2,3,4,5,6,7,8,9,
            //0,1,2,3,4,5,6,7,8,9};

            //List<Point> values = new List<Point>(Zip(xValues, yValues, (x, y) => new Point(x, y)));
            //foreach (var p in values)
            //{
            //    Console.WriteLine($"x is {p.X},y is {p.Y}");
            //}


            
            StreamReader streamReader = new StreamReader("../../abc.txt");


            var readValues = new InputCollection<Point>((inputStream) => new Point(streamReader));
            readValues.ReadFromStream(streamReader);


            foreach (var p in readValues.Values)
            {
                Console.WriteLine($"x is {p.X},y is {p.Y}");
            }
        }



        public static IEnumerable<TOutput> Zip<T1, T2, TOutput>(IEnumerable<T1> left, IEnumerable<T2> right, Func<T1, T2, TOutput> generator)
        {
            IEnumerator<T1> leftSource = left.GetEnumerator();
            IEnumerator<T2> rightSource = right.GetEnumerator();

            while (leftSource.MoveNext() && rightSource.MoveNext())
            {
                yield return generator(leftSource.Current, rightSource.Current);
            }

            leftSource.Dispose();
            rightSource.Dispose();
        }
    }

    public delegate T CreateFromStream<T>(TextReader reader);

    public class InputCollection<T>
    {
        private List<T> thingsRead = new List<T>();
        private readonly CreateFromStream<T> readFunc;
        public InputCollection(CreateFromStream<T> readFunc)
        {
            this.readFunc = readFunc;
        }

        public void ReadFromStream(TextReader reader) => thingsRead.Add(readFunc(reader));
        public IEnumerable<T> Values => thingsRead;
    }


}
