using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex06
{
    //第6条：不要用表示符号名称的硬字符串来调用API
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Person : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
