using System;

namespace ConsoleApp1
{
    delegate void MyDelegate();
    class Program
    {
        public static void func1() { Console.WriteLine("첫번째"); }
        public static void func2() { Console.WriteLine("두번째"); }
        public static void func3() { Console.WriteLine("세번째"); }

        static void Main(string[] args)
        {
            /*
            MyDelegate dele = new MyDelegate(func1);
            dele += func2;
            dele += func3;

            dele();
            */

            string path = Application.



        }
    }
}
