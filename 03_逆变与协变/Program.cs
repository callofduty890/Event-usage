using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_逆变与协变
{
    class Mammal { } //父类
    class Dog : Mammal { }//子类
    class Program
    {
        //定义委托
        public delegate Mammal HandlerMethod();
        public delegate void HandlerMethod1(Mammal m);
        public delegate void HandlerMethod2(Dog m);

        public static Mammal FirstHandler()
        {
            Console.WriteLine("first handler");
            return null;
        }
        public static Dog SecondHandler()
        {
            Console.WriteLine("second handler");
            return null;
        }
        public static void ThirdHandler(Mammal m)
        {
            Console.WriteLine("third handler");
        }
        static void Main(string[] args)
        {
            //正常的匹配: 委托和方法一致
            HandlerMethod handler1 = FirstHandler;
            handler1();
            //协变:返回Dog值默认可以转换成Mammal
            HandlerMethod handler2 = SecondHandler;
            handler2();
            //=============================================
            //正常匹配
            HandlerMethod1 handler3 = ThirdHandler;
            Mammal m = new Mammal();
            handler3(m);
            //逆变:参数Dog(子类)默认可以转换成Mammal(父类)
            HandlerMethod2 handler4 = ThirdHandler;
            Dog d = new Dog();
            handler4(d);

            Console.ReadKey();





        }
    }
}
