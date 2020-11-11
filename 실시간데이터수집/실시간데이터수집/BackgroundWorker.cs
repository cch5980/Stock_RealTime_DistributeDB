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
    class BackgroundWorker
    {
        int offset = 0;
        Stopwatch sw = new Stopwatch();
        int idx = 0;

        public void ReadAndInsert()
        {
            sw.Start();
            while(isReadFileRemainData())
            {
                CheDataDBInsert(ReadCSV());
                if(idx == 10)
                {
                    sw.Stop();
                    Console.WriteLine("DB 삽입 걸린 시간 : " + sw.ElapsedMilliseconds);
                }
                idx++;
            }
        }

        public Boolean isReadFileRemainData()
        {
            sw.Restart();
            int remainDataNum = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv").Skip(offset).Take(1000).Count();
            sw.Stop();
            Console.WriteLine("버틀넥1 : " + sw.ElapsedMilliseconds);
            if (remainDataNum > 0) return true;
            else return false;
        }

        public List<string[]> ReadCSV()
        {
            sw.Restart();
            List<string[]> che_data_list = new List<string[]>();
            sw.Stop();
            Console.WriteLine("버틀넥2 : " + sw.ElapsedMilliseconds);
            sw.Restart();
            string[] file_data_arr = File.ReadLines(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv").Skip(offset).Take(1000).ToArray();
            sw.Stop();
            Console.WriteLine("버틀넥3 : " + sw.ElapsedMilliseconds);
            sw.Restart();
            int idx = 0;
            foreach(string che_data_str in file_data_arr)
            {
                string[] che_data_arr = che_data_str.Split(',');
                che_data_list.Add(che_data_arr);
                idx++;
            }
            sw.Stop();
            Console.WriteLine("버틀넥4 : " + sw.ElapsedMilliseconds);
            offset += idx;
            Console.WriteLine("offset : " + offset);
            return che_data_list;
        }

        public void CheDataDBInsert(List<string[]> cheDataList)
        {
            sw.Restart();
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
            sw.Stop();
            Console.WriteLine("버틀넥5 : " + sw.ElapsedMilliseconds);
        }




    }
}
