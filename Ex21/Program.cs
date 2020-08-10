using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex21
{
    //第21条：创建泛型类时，总是应该给实现了IDisposable的类型参数提供支持
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public interface IEngine
    {
        void DoWork();
    }
    public class EngineDriveOne<T> where T : IEngine, new()
    {
        public void GetThingsDone()
        {
            T driver = new T();
            using (driver as IDisposable)
            {
                driver.DoWork();
            }
        }
    }

    public sealed class EngineDriver2<T> : IDisposable where T : IEngine, new()
    {
        private Lazy<T> driver = new Lazy<T>(() => new T());

        public void GetThingsDone() => driver.Value.DoWork();

        //IDisposable Members
        public void Dispose()
        {
            if (driver.IsValueCreated)
            {
                var resource = driver.Value as IDisposable;
                resource?.Dispose();
            }
        }
    }


    public sealed class EngineDriver<T> where T : IEngine
    {
        private T driver;
        public EngineDriver(T driver)
        {
            this.driver = driver;
        }

        public void GetThingsDone()
        {
            driver.DoWork();
        }
    }
}
