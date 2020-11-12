using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace 실시간데이터수집
{
    public partial class Form1 : Form
    {
        int screenNum = 1000;   // 스크린 번호
        string[] stockCodeArr;  // 종목코드(장내, 코스닥) 배열
        // private BackgroundWorker worker;
        private SQLiteConnection conn = null;
        private StreamWriter writer;
        private string csvWriteForStockCode;
        private string che_data_str;
        private string[] che_data_arr;
        SQLiteCommand cmd = new SQLiteCommand();
        Stopwatch sw = new Stopwatch();
        private SQLiteTransaction transaction;

        public Form1()
        {
            InitializeComponent();

            axKHOpenAPI1.OnEventConnect += API_onEventConnect;
            axKHOpenAPI1.OnReceiveRealData += API_onReceiveData;
            StockSearchButton.Click += stockSearch ;
            csvOutputButton.Click += csvWriteCheDataBtnClick;

            axKHOpenAPI1.CommConnect();
        }

        // STOCK_CHE 테이블 Insert
        private void cheDataDBInsert(List<string[]> cheDataList)
        {
            transaction = conn.BeginTransaction();
            foreach (string[] cheDataArr in cheDataList)
            {
                string sql = "insert into stock_che2 (che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap) VALUES (@che_stock_code, @che_date, @che_time, @che_price, @che_change, @che_change_rate, @che_volume, @che_cumulative_volume, @che_cumulative_amount, @che_open, @che_high, @che_low, @che_trans_amount_change, @che_vp, @che_market_cap)";
                // SQLiteCommand cmd = new SQLiteCommand(sql, conn);

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
            }
            transaction.Commit();
        }

        private void writeCsvToDB()
        {
            int idx = 0;
            StreamReader sr = new StreamReader(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201106).csv");
            List<string[]> che_data_list = new List<string[]>();
            sw.Start();
            while (!sr.EndOfStream)
            {
                che_data_str = sr.ReadLine();
                che_data_arr = che_data_str.Split(',');
                if (che_data_arr.Length == 15)
                {
                    che_data_list.Add(che_data_arr);
                    idx++;
                }
                if (idx % 1000 == 0)
                {
                    cheDataDBInsert(che_data_list);
                    che_data_list.Clear();
                }
            }
            if(che_data_list.Count > 0)
            {
                cheDataDBInsert(che_data_list);
            }
            sw.Stop();
            Console.WriteLine("걸린 시간 : " + sw.ElapsedMilliseconds);
        }

        private void csvFileWrite(string che_stock_code, string che_date, string che_time, string che_price, string che_change, string che_change_rate, string che_volume, string che_cumulative_volume, string che_cumulative_amount, string che_open, string che_high, string che_low, string che_trans_amount_change, string che_vp, string che_market_cap)
        {
            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap);
        }


        private void stockSearch(Object sender, EventArgs e) 
        {
            StockListDataGridView.Rows.Clear();
            string searchStockTitle = StockSearchTextBox.Text;
            Console.WriteLine("검색명 : " + searchStockTitle);
            if(searchStockTitle.Length == 0)
            {
                for (int i = 0; i < stockCodeArr.Length - 1; i++)
                {
                    StockListDataGridView.Rows.Add();
                    StockListDataGridView["종목조회_종목코드", i].Value = stockCodeArr[i];
                    StockListDataGridView["종목조회_종목명", i].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]);
                }
            }
            else
            {
                int idx = 0;
                for (int i = 0; i < stockCodeArr.Length - 1; i++)
                {
                    if(stockCodeArr[i].Contains(searchStockTitle) || axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]).Contains(searchStockTitle))
                    {
                        StockListDataGridView.Rows.Add();
                        StockListDataGridView["종목조회_종목코드", idx].Value = stockCodeArr[i];
                        StockListDataGridView["종목조회_종목명", idx].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]);
                        idx++;
                    }
                }
            }
        }

        private void processInit()
        {
            // DB 연결
            Database.DBConnect();
            Boolean isFileExist = false;
            // Write 파일 객체 초기화
            // writer = File.AppendText(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv");
            // writer.Close();
            if (File.Exists(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv"))
            {
                isFileExist = true;
            }
            FileStream fs = File.Open(@"C:\\Users\\cch\\Desktop\\실시간주가\\stock(201112).csv", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            writer = new StreamWriter(fs);
            if(!isFileExist) writer.WriteLine("che_stock_code,che_date,che_time,che_price,che_change,che_change_rate,che_volume,che_cumulative_volume,che_cumulative_amount,che_open,che_high,che_low,che_trans_amount_change,che_vp,che_market_cap");
        }

        private void API_onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                Console.WriteLine("로그인 성공");
                processInit(); // 초기 작업

                getStockCode();
                stockReaTimeDataRequest();

                // Thread t1 = new Thread(new ThreadStart(writeCsvToDB));
                // t1.Start();
                // writeCsvToDB();

                // Database.DBConnect();
                Background1 bw = new Background1();

                Thread t2 = new Thread(new ThreadStart(bw.ReadAndInsert));
                t2.IsBackground = true;
                t2.Start();

                /*
                worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(bw.ReadAndInsert);
                worker.RunWorkerAsync();
                */

                
            }
            else
            {
                Console.WriteLine("로그인 실패");
            }
        }

        private void API_onReceiveData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식체결")
            {
                // Console.WriteLine("실시간 데이터 : " + e.sRealData);
                // Console.WriteLine("종목 코드 : " + e.sRealKey + ", 현재가 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 10) + ", 체결시간 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 20));

                // e.sRealKey
                // 종목코드, 체결날짜, 체결시간, 현재가, 전일대비, 등락율, 거래량, 누적거래량, 누적거래대금, 시가, 고가, 저가, 거래대금증감, 체결강도, 시가총액
                csvFileWrite(e.sRealKey, DateTime.Now.ToString("yyyy-MM-dd"), axKHOpenAPI1.GetCommRealData(e.sRealKey, 20).Insert(4,":").Insert(2,":"), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10), axKHOpenAPI1.GetCommRealData(e.sRealKey, 11), axKHOpenAPI1.GetCommRealData(e.sRealKey, 12), axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 13), axKHOpenAPI1.GetCommRealData(e.sRealKey, 14), axKHOpenAPI1.GetCommRealData(e.sRealKey, 16), axKHOpenAPI1.GetCommRealData(e.sRealKey, 17), axKHOpenAPI1.GetCommRealData(e.sRealKey, 18), axKHOpenAPI1.GetCommRealData(e.sRealKey, 29), axKHOpenAPI1.GetCommRealData(e.sRealKey, 228), axKHOpenAPI1.GetCommRealData(e.sRealKey, 311));

                /*
                // DB 삽입
                sw.Start();
                stockRealTimeDataDBInsert(e.sRealKey, datetimePreProcess(axKHOpenAPI1.GetCommRealData(e.sRealKey, 20)), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10), axKHOpenAPI1.GetCommRealData(e.sRealKey, 11), axKHOpenAPI1.GetCommRealData(e.sRealKey, 12), axKHOpenAPI1.GetCommRealData(e.sRealKey, 27), axKHOpenAPI1.GetCommRealData(e.sRealKey, 28), axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 13));
                sw.Stop();
                Console.WriteLine("체결시간 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 20) + ", 현재시간 : " + DateTime.Now + ", DB 삽입시간 : " + sw.ElapsedMilliseconds.ToString());
                sw.Reset();
                */
            }
            else
            {
                // Console.WriteLine("타입 : " + e.sRealType);
            }
        }

        private void dbConnect()
        {
            Console.WriteLine("DB 연결");
            string strConn = "Data Source=C:\\chichi\\sqliteDB\\mydb.db";
            Console.WriteLine("strConn : " + strConn);

            conn = new SQLiteConnection(strConn);
            conn.Open();
        }

        private void dbDisconnect()
        {
            if(conn != null)
            {
                conn.Close();
            }
        }

        // STOCK 테이블 Insert
        private void stockDBInesrt(string stock_code, string stock_name)
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

        // REALTIME_CHE 테이블 Insert
        private void stockRealTimeDataDBInsert(string stock_code, string realtime_datetime, string realtime_price, string realtime_yesterday, string realtime_fluctutation, string realtime_sell, string realtime_buy, string realtime_volume, string realtime_cumul_volume)
        {
            string sql = "insert into realtime_che (STOCK_CODE, realtime_datetime, realtime_price, realtime_yesterday, realtime_fluctutation, realtime_sell, realtime_buy, realtime_volume, realtime_cumul_volume) VALUES (@STOCK_CODE, @realtime_datetime, @realtime_price, @realtime_yesterday, @realtime_fluctutation, @realtime_sell, @realtime_buy, @realtime_volume, @realtime_cumul_volume)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@STOCK_CODE", DbType.String);
            cmd.Parameters.Add("@realtime_datetime", DbType.DateTime);
            cmd.Parameters.Add("@realtime_price", DbType.String);
            cmd.Parameters.Add("@realtime_yesterday", DbType.String);
            cmd.Parameters.Add("@realtime_fluctutation", DbType.String);
            cmd.Parameters.Add("@realtime_sell", DbType.String);
            cmd.Parameters.Add("@realtime_buy", DbType.String);
            cmd.Parameters.Add("@realtime_volume", DbType.String);
            cmd.Parameters.Add("@realtime_cumul_volume", DbType.String);
            cmd.Prepare();

            cmd.Parameters[0].Value = stock_code;
            cmd.Parameters[1].Value = realtime_datetime;
            cmd.Parameters[2].Value = realtime_price;
            cmd.Parameters[3].Value = realtime_yesterday;
            cmd.Parameters[4].Value = realtime_fluctutation;
            cmd.Parameters[5].Value = realtime_sell;
            cmd.Parameters[6].Value = realtime_buy;
            cmd.Parameters[7].Value = realtime_volume;
            cmd.Parameters[8].Value = realtime_cumul_volume;
            cmd.ExecuteNonQuery();
        }

        private void stockReaTimeDataRequest()
        {
            // 실시간 연결 요청
            string stockCodeStr = "";
            for(int i=0; i< stockCodeArr.Length; i++)
            {
                stockCodeStr += (stockCodeArr[i]+";");
                // 한번 등록가능한 종목이 100개 => 100으로 나눴을때 나머지가 99이면 요청
                // 마지막 인덱스에 도달했으면 요청
                if((i % 100 == 99) || (i == (stockCodeArr.Length-1)))
                {
                    Console.WriteLine(i + "번째까지의 장내 데이터 호출");
                    axKHOpenAPI1.SetRealReg(getScreenNum(), stockCodeStr, "10", "1");
                    stockCodeStr = "";
                }
            }
        }


        // 전종목에 대한 종목코드 가져오기
        private void getStockCode()
        {
            // 종목코드
            string stockCodeListStr = axKHOpenAPI1.GetCodeListByMarket("0") + axKHOpenAPI1.GetCodeListByMarket("10"); // 장내 + 코스닥
            stockCodeArr = stockCodeListStr.Substring(0, stockCodeListStr.Length - 1).Split(';');

            /*
            // 디비에서 종목 가져오기 -> 해쉬테이블에 저장
            Hashtable hashStockCode = new Hashtable();
            string sql = "select stock_code, stock_name from stock";
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            SQLiteDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                hashStockCode.Add(rdr["stock_code"], rdr["stock_name"]);
            }
            rdr.Close();

            // API종목과 디비 종목 비교
            for(int i=0; i<stockCodeList.Length-1; i++)
            {
                if(!hashStockCode.ContainsKey(stockCodeList[i]))
                {
                    // 디비에 종목코드가 없다면 insert 해준다.
                    Console.WriteLine("종목 코드 : " + stockCodeList[i] + ", 종목명 : " + axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]));
                    stockDBInesrt(stockCodeList[i], axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]));
                }
                StockListDataGridView.Rows.Add();
                StockListDataGridView["종목조회_종목코드", i].Value = stockCodeList[i];
                StockListDataGridView["종목조회_종목명", i].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]);
            }

            */
        }

        // 날짜 변환
        private string datetimePreProcess(string dateStr)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = Int32.Parse(dateStr.Substring(0, 2));
            int minute = Int32.Parse(dateStr.Substring(2, 2));
            int second = Int32.Parse(dateStr.Substring(4, 2));

            DateTime date = new DateTime(year, month, day, hour, minute, second);
            // Console.WriteLine(date.ToString());

            string result = DateTime.Parse(date.ToString(), new System.Globalization.CultureInfo("ko-KR", true)).ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        private string getScreenNum()
        {
            screenNum++;
            return screenNum.ToString();
        }

        private void DB_Select_csvCheData(string realtime_datetime, string fileName)
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

        // CSV 내보내기 이벤트
        private void csvWriteCheDataBtnClick(Object sender, EventArgs e)
        {
            
            string fileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장경로를 지정하세요";
            saveFileDialog.OverwritePrompt = true;

            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                // Console.WriteLine(fileName);

                List<string> checkedCheDateList = new List<string>();
                foreach (DataGridViewRow row in StockCheDateDataGridView.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == "True")
                    {
                        Console.WriteLine(row.Cells[1].Value.ToString());
                        checkedCheDateList.Add(row.Cells[1].Value.ToString());
                    }
                }
                // 쿼리
                for (int i = 0; i < checkedCheDateList.Count; i++)
                {
                    DB_Select_csvCheData(checkedCheDateList[i], fileName);
                }
            }

            
        }

        // 종목 더블클릭 이벤트
        private void StockListDataGridView_DoubleClick(object sender, EventArgs e)
        {
            string searchStockCode = StockListDataGridView.CurrentRow.Cells["종목조회_종목코드"].Value.ToString();
            Console.WriteLine("선택된 종목 코드 : " + searchStockCode);
            csvWriteForStockCode = searchStockCode;
            List<string> stockCheDateList = stockCheDateSelect(searchStockCode);
            StockCheDateDataGridView.Rows.Clear();
            for (int i=0; i<stockCheDateList.Count; i++)
            {
                StockCheDateDataGridView.Rows.Add();
                StockCheDateDataGridView["che_date", i].Value = stockCheDateList[i];
            }
        }

        private List<string> stockCheDateSelect(string stock_code)
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

    }
}
