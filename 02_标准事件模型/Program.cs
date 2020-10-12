using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_标准事件模型
{
    //步骤1:声明提供事件数据的类
    public class NameListEventArgs : EventArgs
    {
        private string _name;
        private int _count;
        public string Name { get => _name; set => _name = value; }
        public int Count { get => _count; set => _count = value; }
        //构造函数
        public NameListEventArgs(string name, int count)
        {
            this.Name = name;this.Count = count;
        }
    }
    //步骤2:声明事件处理委托
    public delegate void NameListEventHandler(NameListEventArgs args);
    //步骤3:声明引发时间的类(事件生产类)
    public class NameList
    {
        ArrayList list;
        //步骤4：在生产类中，声明事件
        public event NameListEventHandler nameListEvent;
        //构造函数
        public NameList()
        {
            list = new ArrayList();
        }
        //添加
        public void Add(string Name)
        {
            list.Add(Name);
            //步骤5:在事件生产类中，实现产生事件的代码
            if (nameListEvent !=null)
            {
                nameListEvent(new NameListEventArgs(Name, list.Count));
            }
        }
    }

    //步骤6:声明处理事件的类(事件消费类)
    class Program
    {
        //步骤7:在事件消费类中，声明事件处理方法
        public static void Method1(NameListEventArgs args)
        {
            Console.WriteLine("列中中增加了项目:{0}", args.Name);
        }
        public static void Method2(NameListEventArgs args)
        {
            Console.WriteLine("列表中的项目数:{0}", args.Count);
        }
        //主入口函数
        static void Main(string[] args)
        {
            NameList n1 = new NameList();
            //步骤8:在事件消费类中，订阅或取消事件
            n1.nameListEvent += new NameListEventHandler(Method1);
            n1.nameListEvent += new NameListEventHandler(Method2);

            //触发事件
            n1.Add("张三");
            n1.Add("李四");
            n1.Add("王五");

            Console.ReadKey();
        }
    }
}
