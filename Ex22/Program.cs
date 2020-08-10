using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex22
{
    //第22条：考虑支持泛型协变与逆变
    class Program
    {
        static void Main(string[] args)
        {
        }


    }


    public interface ICovariantDelegates<out T>
    {
        T GetAnItem();
        Func<T> GetAnItemLater();
        void GiveAnItemLater(Action<T> whatToDo);
    }

    public interface IContravariantDelegates<in T>
    {
        void ActOnAnItem(T item);
        void GetAnItemLater(Func<T> item);
        Action<T> ActOnAnItemLater();

    }
}
