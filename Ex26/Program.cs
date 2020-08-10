using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex26
{
    //第26条：实现泛型接口的同时，还应该实现非泛型接口
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Name : IComparable<Name>, IEquatable<Name>,IComparable
    {
        public string First { get; set; }
        public string Last { get; set; }
        public string Middle { get; set; }

        //IComparable<Name> Members
        public int CompareTo(Name other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return 0;
            }
            if (Object.ReferenceEquals(other, null))
            {
                return 1;//any non-null object > null
            }
            int rVal = Comparer<string>.Default.Compare(Last, other.Last);
            if (rVal != 0)
            {
                return rVal;
            }

            rVal = Comparer<string>.Default.Compare(First, other.First);
            if (rVal != 0)
            {
                return rVal;
            }

            return Comparer<string>.Default.Compare(Middle, other.Middle);
        }


        //IEquatable<Name> Members
        public bool Equals(Name other)
        {
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            return Last == other.Last && First == other.First && Middle == other.Middle;
        }

        //IComparable Members
        int IComparable.CompareTo(object obj)
        {
            if (obj.GetType()!=typeof(Name))
            {
                throw new ArgumentException("Argument is not a Name object");
            }

            return this.CompareTo(obj as Name);
        }

        public static bool operator <(Name left, Name right)
        {
            if (left==null)
            {
                return right != null;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Name left, Name right)
        {
            if (left==null)
            {
                return false;
            }

            return left.CompareTo(right) < 0;
        }

        public static bool operator <=(Name left, Name right)
        {
            if (left==null)
            {
                return true;
            }
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(Name left, Name right)
        {
            if (left==null)
            {
                return right == null;
            }
            return left.CompareTo(right) >= 0;
        }
    }
}
