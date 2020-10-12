using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_泛型委托
{


    class Program
    {
        public delegate void del<T>(T item);//泛型

        public static void Notify(int i){}
        public static void DoubleNotify(double j) { }

        del<int> m1 = new del<int>(Notify);
        del<double> m2 = new del<double>(DoubleNotify);

        static void Main(string[] args)
        {
        }
    }
}
