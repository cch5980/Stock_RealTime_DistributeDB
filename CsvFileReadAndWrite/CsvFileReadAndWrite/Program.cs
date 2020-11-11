using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvFileReadAndWrite
{
    class Program
    {
        static StreamWriter writer;
        static int offset = 0;

        static void OnReceiveRealData(string s)
        {
            writer.WriteLine(s);
            Console.WriteLine(s);

        }

        static void Main(string[] args)
        {
            // writer = File.AppendText(@"C:\\Users\\cch\\Desktop\\실시간주가\\test4.csv");
            // IEnumerable<string> fileStr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv");
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IEnumerable<string> fileStr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\test4.csv");
            sw.Stop();
            Console.WriteLine("걸린 시간1 : " + sw.ElapsedMilliseconds);
            sw.Restart();
            IEnumerable<string> fileStr2 = fileStr.Skip(0);
            sw.Stop();
            Console.WriteLine("걸린 시간2 : " + sw.ElapsedMilliseconds);
            sw.Restart();
            IEnumerable<string> fileStr3 = fileStr2.Take(1200);
            sw.Stop();
            Console.WriteLine("걸린 시간3 : " + sw.ElapsedMilliseconds);
            sw.Restart();
            string[] strArr = fileStr3.ToArray();
            sw.Stop();
            Console.WriteLine("걸린 시간4 : " + sw.ElapsedMilliseconds);
            Console.WriteLine("배열 개수 : " + strArr.Length);

            int idx = 0;
            foreach(string str in strArr)
            {
                // writer.WriteLine(str);
                Console.WriteLine("idx : " + idx + "@" + str);
                idx++;
            }
            Console.WriteLine(strArr.Length);
            // writer.Flush();
            

            /*
            sw.Restart();
            while (File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv").Skip(offset).Count() > 0)
            {
                sw.Stop();
                Console.WriteLine("걸린 시간1 : " + sw.ElapsedMilliseconds);
                sw.Restart();
                string[] file_data_arr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv").Skip(offset).ToArray();
                sw.Stop();
                Console.WriteLine("걸린 시간2 : " + sw.ElapsedMilliseconds);
                sw.Restart();


                int idx = 0;
                Console.WriteLine(file_data_arr.Length);
                foreach (string che_data_str in file_data_arr)
                {
                    writer.WriteLine(che_data_str);
                    idx++;
                    if (idx == 1000) break;
                }
                offset += idx;
                sw.Stop();
                Console.WriteLine("걸린 시간3 : " + sw.ElapsedMilliseconds);
                Console.WriteLine("offset : " + offset);
                break;
            }
            */


            // Test t = new Test();
            // t.ReadFile();

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