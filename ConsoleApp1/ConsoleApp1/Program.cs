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

            // string path = Application.
            string str = "092244";
            // Console.WriteLine(str.Substring(0, 1));
            Console.WriteLine(DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd tt ") + str.Substring(0,2) + ":" + str.Substring(2, 2) + ":" + str.Substring(4, 2), "yyyy-MM-dd tt hh:mm:ss", null));
            Console.WriteLine(DateTime.Today.Year);
            // Console.WriteLine(DateTime.ParseExact(DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day + str.Substring(0, 1) + " " + str.Substring(2, 1) + " " + str.Substring(4, 1), "yyyy-MM-dd tt hh:mm:ss", null));
            // Console.WriteLine(new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, int.Parse(str.Substring(0, 1)), int.Parse(str.Substring(2, 3)), int.Parse(str.Substring(4, 5))).ToString());
        }
    }
}
