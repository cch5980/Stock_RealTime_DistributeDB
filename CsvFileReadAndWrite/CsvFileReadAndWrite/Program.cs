using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileReadAndWrite
{
    class Program
    {
        static StreamWriter writer;

        static void OnReceiveRealData(string s)
        {
            writer.WriteLine(s);
            Console.WriteLine(s);

        }

        static void Main(string[] args)
        {

            Test t = new Test();
            t.ReadFile();

            /*
            StreamReader sr = new StreamReader(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock_update.csv");
            int i = 0;
            Console.WriteLine(sr.ReadLine());
            Console.WriteLine("으따");
            while (!sr.EndOfStream)
            {
                Console.WriteLine(sr.ReadLine());
                i++;
                if (i > 10) break;
            }
            */

            /*
            Stopwatch sw = new Stopwatch();
            sw.Start();
            StreamReader sr = new StreamReader(@"C:\\Users\\cch\\Desktop\\실시간주가\\2020-11-04.csv");
            int i = 0;
            writer = File.AppendText(@"C:\\Users\\cch\\Desktop\\실시간주가\\test3.csv");
            while (!sr.EndOfStream)
            {
                OnReceiveRealData(sr.ReadLine());
            }
            writer.Close();
            */

            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\cch\\Desktop\\실시간주가\\test.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    file.WriteLine(s);
                    i++;
                   
                    Console.WriteLine(s);
                }
            }
            */


            // sw.Stop();
            // Console.WriteLine("걸린 시간 : " + sw.Elapsed.ToString());



            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\\Users\\cch\\Desktop\\실시간주가\\test.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    string[] temp = s.Split(',');        // Split() 메서드를 이용하여 ',' 구분하여 잘라냄
                    string str = "";
                    for (int j = 0; j < temp.Length; j++)
                    {
                        str += (temp[j] + ", ");
                    }
                    file.WriteLine(str.Substring(0, str.Length - 2));
                    i++;
                    // if (i > 10) break;
                    Console.WriteLine("i : " + i);
                }
            }
            */

        }

    }
}