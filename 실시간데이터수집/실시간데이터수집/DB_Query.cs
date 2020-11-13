using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 실시간데이터수집
{
    class DB_Query
    {
        private SQLiteConnection conn = null;

        public void setDBConnection(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        // 종목코드 및 종목명 삽입
        public void Insert_stockDB(string stock_code, string stock_name)
        {
            string sql = "insert into stock (STOCK_CODE, STOCK_NAME) VALUES (@STOCK_CODE, @STOCK_NAME)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@STOCK_CODE", DbType.String);
            cmd.Parameters.Add("@STOCK_NAME", DbType.String);
            cmd.Prepare();

            cmd.Parameters[0].Value = stock_code;
            cmd.Parameters[1].Value = stock_name;
            cmd.ExecuteNonQuery();
        }

        // DB 내 체결데이터 전체 개수
        public int Select_AllCheCount()
        {
            string sql = "select count(che_stock_code) from stock_che3;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int result = rdr.GetInt32(0);
            rdr.Close();
            return result;
        }

        // 종목 코드 전체 조회
        public Hashtable Select_All_StockCode()
        {
            Hashtable hashStockCode = new Hashtable();
            string sql = "select stock_code, stock_name from stock";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                hashStockCode.Add(rdr["stock_code"], rdr["stock_name"]);
            }
            rdr.Close();
            return hashStockCode;
        }

        public int Insert_CheDataDB(List<string[]> cheDataList)
        {
            SQLiteTransaction transaction = conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand();
            string sql = "insert into stock_che3 (che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap) VALUES (@che_stock_code, @che_date, @che_time, @che_price, @che_change, @che_change_rate, @che_volume, @che_cumulative_volume, @che_cumulative_amount, @che_open, @che_high, @che_low, @che_trans_amount_change, @che_vp, @che_market_cap)";
            cmd.Connection = conn;
            cmd.CommandText = sql;

            cmd.Parameters.Add("@che_stock_code", DbType.String);
            cmd.Parameters.Add("@che_date", DbType.String);
            cmd.Parameters.Add("@che_time", DbType.String);
            cmd.Parameters.Add("@che_price", DbType.String);
            cmd.Parameters.Add("@che_change", DbType.String);
            cmd.Parameters.Add("@che_change_rate", DbType.String);
            cmd.Parameters.Add("@che_volume", DbType.String);
            cmd.Parameters.Add("@che_cumulative_volume", DbType.String);
            cmd.Parameters.Add("@che_cumulative_amount", DbType.String);
            cmd.Parameters.Add("@che_open", DbType.String);
            cmd.Parameters.Add("@che_high", DbType.String);
            cmd.Parameters.Add("@che_low", DbType.String);
            cmd.Parameters.Add("@che_trans_amount_change", DbType.String);
            cmd.Parameters.Add("@che_vp", DbType.String);
            cmd.Parameters.Add("@che_market_cap", DbType.String);
            cmd.Prepare();

            int idx = 0;
            foreach (string[] cheDataArr in cheDataList)
            {
                cmd.Parameters[0].Value = cheDataArr[0];
                cmd.Parameters[1].Value = cheDataArr[1];
                cmd.Parameters[2].Value = cheDataArr[2];
                cmd.Parameters[3].Value = cheDataArr[3];
                cmd.Parameters[4].Value = cheDataArr[4];
                cmd.Parameters[5].Value = cheDataArr[5];
                cmd.Parameters[6].Value = cheDataArr[6];
                cmd.Parameters[7].Value = cheDataArr[7];
                cmd.Parameters[8].Value = cheDataArr[8];
                cmd.Parameters[9].Value = cheDataArr[9];
                cmd.Parameters[10].Value = cheDataArr[10];
                cmd.Parameters[11].Value = cheDataArr[11];
                cmd.Parameters[12].Value = cheDataArr[12];
                cmd.Parameters[13].Value = cheDataArr[13];
                cmd.Parameters[14].Value = cheDataArr[14];
                cmd.ExecuteNonQuery();
                idx++;
            }
            transaction.Commit();
            return idx;
        }

    }
}
