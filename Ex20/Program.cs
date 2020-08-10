using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex20
{
    //第20条：通过IComparable<T>及IComparer<T>定义顺序关系
    class Program
    {
        static void Main(string[] args)
        {
            Customer c1 = new Customer();
            object o1 = new object();

            IComparable iC1 = c1 as IComparable;
            if (((IComparable)c1).CompareTo(o1) > 0)
            {

            }
            if (iC1.CompareTo(o1) > 0)
            {

            }
        }
    }

    public struct Customer : IComparable<Customer>, IComparable
    {
        private readonly string name;
        private double revenue;
        public Customer(string name, double revenue)
        {
            this.name = name;
            this.revenue = revenue;
        }

        //IComparable<Customer> Members
        public int CompareTo(Customer other) => name.CompareTo(other.name);
        //IComparable Members
        int IComparable.CompareTo(object obj)
        {
            if (!(obj is Customer))
            {
                throw new ArgumentException("Argumnet is not a Customer", "obj");
            }

            Customer otherCustomer = (Customer)obj;

            return this.CompareTo(otherCustomer);
        }

        //Relation Operators
        public static bool operator <(Customer left, Customer right) => left.CompareTo(right) < 0;
        public static bool operator <=(Customer left, Customer right) => left.CompareTo(right) <= 0;
        public static bool operator >(Customer left, Customer right) => left.CompareTo(right) > 0;
        public static bool operator >=(Customer left, Customer right) => left.CompareTo(right) >= 0;

        private static Lazy<RevenueComparer> revComp = new Lazy<RevenueComparer>(() => new RevenueComparer());

        public static IComparer<Customer> RevenueCompare => revComp.Value;

        public static Comparison<Customer> CompareByRevenue => (left, right) => left.revenue.CompareTo(right.revenue);


        private class RevenueComparer : IComparer<Customer>
        {
            //IComparer<Customer> Members
            int IComparer<Customer>.Compare(Customer left, Customer right)
            {
                return left.revenue.CompareTo(right.revenue);
            }
        }
    }
}
