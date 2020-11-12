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

        int offset = 1; // 맨 첫줄은 애트리뷰트명
        Stopwatch sw = new Stopwatch();
        string[] file_data_arr;

        public void ReadAndInsert()
        {
            while (IsReadFileRemainData())
            {
                CheDataDBInsert(ReadCSV());
            }
        }

        public Boolean IsReadFileRemainData()
        {
            // file share로 열어줌
            // FileStream fs = File.Open(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // 기존 로직
            file_data_arr = ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv").Skip(offset).Take(1000).ToArray();
            // file_data_arr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv").Skip(offset).Take(1000).ToArray();
            int remainDataNum = file_data_arr.Length;
            Console.WriteLine("파일에 데이터 있누 : " + file_data_arr.Length);
            if (remainDataNum > 0) return true;
            else return false;
        }

        public List<string[]> ReadCSV()
        {
            List<string[]> che_data_list = new List<string[]>();
            // string[] file_data_arr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv").Skip(offset).Take(1000).ToArray();
            int dataLength = file_data_arr.Length;
            if (file_data_arr[file_data_arr.Length - 1].Split(',').Length < 15)
            {
                dataLength -= 1;
            } 
            for(int i = 0; i < dataLength; i++)
            {
                string[] che_data_arr = file_data_arr[i].Split(',');
                che_data_list.Add(che_data_arr);
            }
            offset += dataLength;
            Console.WriteLine("offset : " + offset);
            return che_data_list;
        }

        public void CheDataDBInsert(List<string[]> cheDataList)
        {
            Database.transaction = Database.conn.BeginTransaction();
            foreach (string[] cheDataArr in cheDataList)
            {
                string sql = "insert into stock_che3 (che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap) VALUES (@che_stock_code, @che_date, @che_time, @che_price, @che_change, @che_change_rate, @che_volume, @che_cumulative_volume, @che_cumulative_amount, @che_open, @che_high, @che_low, @che_trans_amount_change, @che_vp, @che_market_cap)";
                // SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                Database.cmd.Connection = Database.conn;
                Database.cmd.CommandText = sql;

                Database.cmd.Parameters.Add("@che_stock_code", DbType.String);
                Database.cmd.Parameters.Add("@che_date", DbType.String);
                Database.cmd.Parameters.Add("@che_time", DbType.String);
                Database.cmd.Parameters.Add("@che_price", DbType.String);
                Database.cmd.Parameters.Add("@che_change", DbType.String);
                Database.cmd.Parameters.Add("@che_change_rate", DbType.String);
                Database.cmd.Parameters.Add("@che_volume", DbType.String);
                Database.cmd.Parameters.Add("@che_cumulative_volume", DbType.String);
                Database.cmd.Parameters.Add("@che_cumulative_amount", DbType.String);
                Database.cmd.Parameters.Add("@che_open", DbType.String);
                Database.cmd.Parameters.Add("@che_high", DbType.String);
                Database.cmd.Parameters.Add("@che_low", DbType.String);
                Database.cmd.Parameters.Add("@che_trans_amount_change", DbType.String);
                Database.cmd.Parameters.Add("@che_vp", DbType.String);
                Database.cmd.Parameters.Add("@che_market_cap", DbType.String);
                Database.cmd.Prepare();

                Database.cmd.Parameters[0].Value = cheDataArr[0];
                Database.cmd.Parameters[1].Value = cheDataArr[1];
                Database.cmd.Parameters[2].Value = cheDataArr[2];
                Database.cmd.Parameters[3].Value = cheDataArr[3];
                Database.cmd.Parameters[4].Value = cheDataArr[4];
                Database.cmd.Parameters[5].Value = cheDataArr[5];
                Database.cmd.Parameters[6].Value = cheDataArr[6];
                Database.cmd.Parameters[7].Value = cheDataArr[7];
                Database.cmd.Parameters[8].Value = cheDataArr[8];
                Database.cmd.Parameters[9].Value = cheDataArr[9];
                Database.cmd.Parameters[10].Value = cheDataArr[10];
                Database.cmd.Parameters[11].Value = cheDataArr[11];
                Database.cmd.Parameters[12].Value = cheDataArr[12];
                Database.cmd.Parameters[13].Value = cheDataArr[13];
                Database.cmd.Parameters[14].Value = cheDataArr[14];
                Database.cmd.ExecuteNonQuery();
            }
            Database.transaction.Commit();
        }

    }
}
