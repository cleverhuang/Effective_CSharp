using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex33
{
    //第33条：等真正用到序列中的元素时再去生成
    class Program
    {
        static void Main(string[] args)
        {
            ////放置在List中
            //var listStorage = new List<int>(CreateSequence(100, 0, 5));

            ////放置在BindingList中
            //var data = new BindingList<int>(CreateSequence(100, 0, 5).ToList());

            //Using an anonymous delegate
            var sequence = CreateSequence(10000, 0, 7).TakeWhile(delegate (int num) { return num < 50; });
            

            //Using lambda notation
            var sequenceOfLam = CreateSequence(10000, 0, 7).TakeWhile((num) => num < 50);


            foreach (var item in sequence)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in sequenceOfLam)
            {
                Console.WriteLine(item);
            }
        }

        //普通的生成函数
        //static IList<int> CreateSequence(int numberOfElements, int startAt, int stepBy)
        //{
        //    var collection = new List<int>(numberOfElements);

        //    for (int i = 0; i < numberOfElements; i++)
        //    {
        //        collection.Add(startAt + i * stepBy);
        //    }

        //    return collection;
        //}

        //迭代器方法实现
        static IEnumerable<int> CreateSequence(int numberOfElements, int startAt, int stepBy)
        {
            for (var i = 0; i < numberOfElements; i++)
            {
                yield return startAt + i * stepBy;
            }
        }
    }
}
