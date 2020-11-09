using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class BackgroundWorker
    {
        string che_data_str;
        string[] che_data_arr;
        StreamReader sr = new StreamReader(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv");
        long offset;
        public List<string[]> ReadCSV()
        {
            Console.WriteLine("백그라운드 워커 실행");
            while(!sr.EndOfStream)
            {
                che_data_str = sr.ReadLine();
                // che_data_arr = che_data_str.Split(',');
                offset = sr.BaseStream.Position;
                Console.WriteLine("offset :" + offset);
            }
            return new List<string[]>();
        }
        // CSV파일 읽기 -> 대신 offset 이용




    }
}
