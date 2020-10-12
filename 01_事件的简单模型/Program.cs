using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_事件的简单模型
{
    class Mom
    {
        public delegate void EatHandler();//创建一个委托
        public event EatHandler EatEvent;//创建一个事件
        private void OnEat()//吃
        {
            if (EatEvent!=null)
            {
                EatEvent();//吃饭的事件
            }
        }
        public void Cook()
        {
            Console.WriteLine("妈妈开始煮饭");
            Console.WriteLine("妈妈开始炒菜");
            OnEat();//发布消息，通知吃饭
        }
    }
    class Dad
    {
        public void Eat()
        {
            Console.WriteLine("爸爸:好的我这就来吃饭了");
        }
    }
    class Son
    {
        public void Eat()
        {
            Console.WriteLine("儿子:妈妈，我再玩一会，马上就过来");
        }
    }

    class SomeOne
    {
        public void Eat()
        {
            Console.WriteLine("客人:好嘞,辛苦你了！我马上过来吃饭");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //实例对象
            Mom objMon = new Mom();
            Dad objDad = new Dad();
            Son objSon = new Son();
            SomeOne objSomeOne = new SomeOne();

            //事件的绑定
            //objMon.EatEvent += new Mom.EatHandler(objSon.Eat);
            objMon.EatEvent += objSon.Eat;
            objMon.EatEvent += objDad.Eat;
            objMon.EatEvent += objSomeOne.Eat;

            //事件的触发
            objMon.Cook();

            Console.ReadKey();

            

        }
    }
}
