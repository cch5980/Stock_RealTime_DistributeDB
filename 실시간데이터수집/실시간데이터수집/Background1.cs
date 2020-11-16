using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class Background1
    {
        public static IEnumerable<string> ReadLines(string path)
        {
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 0x1000, FileOptions.SequentialScan))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }

        private int offset = 1; // 맨 첫줄은 애트리뷰트명
        private int waitInsertDataCount = 0; // DB 삽입 대기 중인 레코드 수
        private string[] file_data_arr; // 체결 데이터
        private DB_Query db_query = new DB_Query(DB_Config.GetDBConnection()); // DB 쿼리

        public int getOffset()
        {
            return this.offset;
        }

        public void setOffset(int offset)
        {
            this.offset = offset;
        }

        public int getWaitInsertDataCount()
        {
            return this.waitInsertDataCount;
        }

        public void ReadAndInsert()
        {
            while (IsReadFileRemainData())
            {
                if (file_data_arr.Length > 0)
                {
                    waitInsertDataCount -= db_query.Insert_CheDataDB(ReadCSV());
                    db_query.Update_fileOffset(getOffset(), "stock(201116)");
                }
            }
        }

        public Boolean IsReadFileRemainData()
        {
            // file share로 열어줌
            file_data_arr = ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201116).csv").Skip(offset).Take(1000).ToArray();
            // int remainDataNum = file_data_arr.Length;
            // if (remainDataNum > 0) return true;
            // else return false;
            return true;
        }

        public List<string[]> ReadCSV()
        {
            List<string[]> che_data_list = new List<string[]>();
            int idx = 0;
            foreach(string che_data in file_data_arr)
            {
                string[] che_data_arr = che_data.Split(',');
                if(che_data_arr.Length == 15)   // Dirty Read Filter
                {
                    che_data_list.Add(che_data_arr);
                    idx++;
                }
            }
            this.offset += idx;
            this.waitInsertDataCount += idx;
            Console.WriteLine("offset : " + offset);
            return che_data_list;
        }

    }
}
