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

        public DB_Query(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        public void setDBConnection(SQLiteConnection conn)
        {
            this.conn = conn;
        }

        // 종목코드별 체결 데이터 상세 조회 - 최근 100건
        public List<string[]> Select_CheDataDetail_Total(string che_stock_code)
        {
            List<string[]> stockCheDataList = new List<string[]>();
            string sql = "select che_time, che_volume, che_price from stock_che where che_stock_code = @CHE_STOCK_CODE;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@CHE_STOCK_CODE", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = che_stock_code;
            SQLiteDataReader rdr = cmd.ExecuteReader(); ;
            while (rdr.Read())
            {
                stockCheDataList.Add(new string[] { rdr["che_time"].ToString(), rdr["che_volume"].ToString(), rdr["che_price"].ToString() });
            }
            rdr.Close();
            return stockCheDataList;
        }

        // 종목코드별 분봉 데이터 조회
        public List<string[]> Select_MinuteData(string che_stock_code)
        {
            List<string[]> stockMinuteDataList = new List<string[]>();
            string sql = "select A.che_date, strftime('%H:%M', A.che_time) as time, A.che_open as open, B.high as high, B.low as low, A.che_price as close from stock_che as A, (select che_date, max(che_time) as closetime, max(che_price) as high, min(che_price) as low from stock_che where che_stock_code = @CHE_STOCK_CODE group by che_date, strftime('%H:%M', che_time)) as B where A.che_date = B.che_date and A.che_time = B.closetime and A.che_stock_code = @CHE_STOCK_CODE group by A.che_date, strftime('%H:%M', A.che_time);";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@CHE_STOCK_CODE", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = che_stock_code;
            SQLiteDataReader rdr = cmd.ExecuteReader(); ;
            Console.WriteLine("@@@ 종목 코드 : " + che_stock_code);
            Console.WriteLine("rdr : " + rdr.FieldCount);
            while (rdr.Read())
            {
                Console.WriteLine(rdr["time"].ToString());
                Console.WriteLine(rdr["open"].ToString());
                Console.WriteLine(rdr["high"].ToString());
                Console.WriteLine(rdr["low"].ToString());
                Console.WriteLine(rdr["close"].ToString());
                stockMinuteDataList.Add(new string[] { rdr["time"].ToString(), rdr["open"].ToString(), rdr["high"].ToString(), rdr["low"].ToString(), rdr["close"].ToString() });
            }
            rdr.Close();
            return stockMinuteDataList;
        }

        // file_offset 삽입(초기 로딩시)
        public void Insert_fileOffset(int file_offset, string file_name)
        {
            string sql = "Insert into file (file_offset, file_name) values (@FILE_OFFSET, @FILE_NAME);";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@FILE_OFFSET", DbType.Int32);
            cmd.Parameters.Add("@FILE_NAME", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = file_offset;
            cmd.Parameters[1].Value = file_name;
            cmd.ExecuteNonQuery();
        }

        // file_offset 수정
        public void Update_fileOffset(int file_offset, string file_name)
        {
            string sql = "update file set file_offset = @FILE_OFFSET where file_name = @FILE_NAME;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@FILE_OFFSET", DbType.Int32);
            cmd.Parameters.Add("@FILE_NAME", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = file_offset;
            cmd.Parameters[1].Value = file_name;
            cmd.ExecuteNonQuery();
        }

        // file_offset 조회
        public int Select_fileOffset(string file_name)
        {
            int result = 1;
            string sql = "select file_offset from file where file_name = @FILE_NAME;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@FILE_NAME", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = file_name;
            SQLiteDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("rdr 크기 : " + rdr.FieldCount);
            if (rdr.FieldCount != 0)
            {
                rdr.Read();
                result = rdr.GetInt32(0);
                rdr.Close();
                return result;
            } else
            {
                rdr.Close();
                return result;
            }
        } 

        // 종목코드별 체결 데이터 상세 조회 - 최근 100건
        public List<string[]> Select_CheDataDetail(string che_stock_code)
        {
            List<string[]> stockCheDataList = new List<string[]>();
            string sql = "select che_date, che_time, che_volume, che_price from stock_che where che_stock_code = @CHE_STOCK_CODE order by che_date desc, che_time desc limit 100;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@CHE_STOCK_CODE", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = che_stock_code;
            SQLiteDataReader rdr = cmd.ExecuteReader();;
            while (rdr.Read())
            {
                stockCheDataList.Add(new string[] { rdr["che_time"].ToString(), rdr["che_volume"].ToString(), rdr["che_price"].ToString() });
            }
            rdr.Close();
            return stockCheDataList;
        }


        // 종목별 전체 체결수
        public Hashtable Select_CheCountByStockCode_Today()
        {
            Hashtable hashStockCheCount = new Hashtable();
            string sql = "select che_stock_code, count(che_date) as count from stock_che where che_date = strftime(\'%Y-%m-%d\', \'now\', \'localtime\') group by che_stock_code;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                hashStockCheCount.Add(rdr["che_stock_code"], rdr["count"]);
            }
            rdr.Close();
            return hashStockCheCount;
        }

        // 종목별 전체 체결수
        public Hashtable Select_CheCountByStockCode_Total()
        {
            Hashtable hashStockCheCount = new Hashtable();
            string sql = "select che_stock_code, count(che_date) as count from stock_che group by che_stock_code;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                hashStockCheCount.Add(rdr["che_stock_code"], rdr["count"]);
            }
            rdr.Close();
            return hashStockCheCount;
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

        // 금일 체결데이터 개수
        public int Select_CheCount_Today()
        {
            string sql = "select count(che_stock_code) from stock_che where che_date = strftime(\'%Y-%m-%d\', \'now\', \'localtime\');";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            int result = rdr.GetInt32(0);
            rdr.Close();
            return result;
        }

        // DB 내 체결데이터 전체 개수
        public int Select_CheCount_Total()
        {
            string sql = "select count(che_stock_code) from stock_che;";
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

        // 체결데이터 삽입
        public int Insert_CheDataDB(List<string[]> cheDataList)
        {
            SQLiteTransaction transaction = conn.BeginTransaction();
            SQLiteCommand cmd = new SQLiteCommand();
            string sql = "insert or ignore into stock_che (che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap) VALUES (@che_stock_code, @che_date, @che_time, @che_price, @che_change, @che_change_rate, @che_volume, @che_cumulative_volume, @che_cumulative_amount, @che_open, @che_high, @che_low, @che_trans_amount_change, @che_vp, @che_market_cap)";
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

        /*
        public void DB_Select_csvCheData(string realtime_datetime, string fileName)
        {
            string sql = "select * from realtime_che where stock_code = @stock_code and date(realtime_datetime) = @realtime_datetime;";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@stock_code", DbType.String);
            cmd.Parameters.Add("@realtime_datetime", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = csvWriteForStockCode;
            cmd.Parameters[1].Value = realtime_datetime;
            SQLiteDataReader rdr = cmd.ExecuteReader();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(fileName + ".csv", false, System.Text.Encoding.GetEncoding("utf-8")))
            {
                // 각 필드에 사용될 제목을 먼저 정의해주자 
                file.WriteLine("종목코드,체결시간,현재가,전일대비,등락율,매도호가,매수호가,거래량,누적거래량");
                while (rdr.Read())
                {
                    // 필드에 값을 채워준다.  
                    file.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8}", rdr["stock_code"].ToString(), rdr["realtime_datetime"].ToString(), rdr["realtime_price"].ToString(), rdr["realtime_yesterday"].ToString(), rdr["realtime_fluctutation"].ToString(), rdr["realtime_sell"].ToString(), rdr["realtime_buy"].ToString(), rdr["realtime_volume"].ToString(), rdr["realtime_cumul_volume"].ToString());
                }
                rdr.Close();
                Console.WriteLine("csv 파일 쓰기 완료");
            }
        }

        public List<string> stockCheDateSelect(string stock_code)
        {
            string sql = "select strftime('%Y-%m-%d', b.realtime_datetime) as che_date from stock as a join realtime_che as b on a.stock_code = b.stock_code where a.stock_code = @STOCK_CODE group by strftime('%Y-%m-%d', b.realtime_datetime);";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@STOCK_CODE", DbType.String);
            cmd.Prepare();
            cmd.Parameters[0].Value = stock_code;
            SQLiteDataReader rdr = cmd.ExecuteReader();
            List<string> stockCheDateList = new List<string>();
            while (rdr.Read())
            {
                stockCheDateList.Add(rdr["che_date"].ToString());
            }
            rdr.Close();
            return stockCheDateList;
        }
        */

    }
}
