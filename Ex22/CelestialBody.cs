using System;
using System.Collections.Generic;

namespace Ex22
{
    abstract public class CelestialBody : IComparable<CelestialBody>
    {
        public double Mass { get; set; }
        public string Name { get; set; }

        public int CompareTo(CelestialBody other)
        {
            return Mass.CompareTo(other.Mass);
        }


        public static void InvariantGeneric(IList<CelestialBody> baseItems)
        {
            baseItems[0] = new Asteroid { Name = "Hygiea", Mass = 8.85e19 };
        }

        public static void CovariantGeneric(IEnumerable<CelestialBody> baseItems)
        {
            foreach (var thing in baseItems)
            {
                Console.WriteLine($"{thing.Name} has a mass of {thing.Mass} Kg.");
            }
        }

        //这个方法可以协变地处理由CelestialBody对象所构成的数组，而且能够保证程序安全运行
        public static void CoVariantArray(CelestialBody[] baseItems)
        {
            foreach (var thing in baseItems)
            {
                Console.WriteLine($"{thing.Name} has a mass of {thing.Mass} Kg.");
            }
        }
        //这个方法也可以协变地处理由CelestialBody对象所组成的数组，但它无法保证程序能够安全运行（因为baseItems未必是一种能够存入Asteroid对象的数组）

        public static void UnsafeVariantArray(CelestialBody[] baseItems)
        {
            baseItems[0] = new Asteroid { Name = "Hygiea", Mass = 8.85e19 };
        }
    }
}
