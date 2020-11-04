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

namespace 실시간데이터수집
{
    public partial class Form1 : Form
    {
        int screenNum = 1000;
        string[] stockCodeList;
        string[] kosdaqCodeList;
        private SQLiteConnection conn = null;
        private string csvWriteForStockCode;
        Stopwatch sw = new Stopwatch();
        public Form1()
        {
            InitializeComponent();

            axKHOpenAPI1.OnEventConnect += API_onEventConnect;
            // axKHOpenAPI1.OnReceiveRealData += API_onReceiveData;
            StockSearchButton.Click += stockSearch ;
            csvOutputButton.Click += csvWriteCheDataBtnClick;

            axKHOpenAPI1.CommConnect();
        }

        

        private void stockSearch(Object sender, EventArgs e) 
        {
            StockListDataGridView.Rows.Clear();
            string searchStockTitle = StockSearchTextBox.Text;
            Console.WriteLine("검색명 : " + searchStockTitle);
            if(searchStockTitle.Length == 0)
            {
                for (int i = 0; i < stockCodeList.Length - 1; i++)
                {
                    StockListDataGridView.Rows.Add();
                    StockListDataGridView["종목조회_종목코드", i].Value = stockCodeList[i];
                    StockListDataGridView["종목조회_종목명", i].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]);
                }
            }
            else
            {
                int idx = 0;
                for (int i = 0; i < stockCodeList.Length - 1; i++)
                {
                    if(stockCodeList[i].Contains(searchStockTitle) || axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]).Contains(searchStockTitle))
                    {
                        StockListDataGridView.Rows.Add();
                        StockListDataGridView["종목조회_종목코드", idx].Value = stockCodeList[i];
                        StockListDataGridView["종목조회_종목명", idx].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]);
                        idx++;
                    }
                }
            }
        }

        private void API_onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                Console.WriteLine("로그인 성공");
                getStockCode();
                // stockReaTimeDataRequest();
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
                // DB 삽입
                sw.Start();
                stockRealTimeDataDBInsert(e.sRealKey, datetimePreProcess(axKHOpenAPI1.GetCommRealData(e.sRealKey, 20)), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10), axKHOpenAPI1.GetCommRealData(e.sRealKey, 11), axKHOpenAPI1.GetCommRealData(e.sRealKey, 12), axKHOpenAPI1.GetCommRealData(e.sRealKey, 27), axKHOpenAPI1.GetCommRealData(e.sRealKey, 28), axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 13));
                sw.Stop();
                Console.WriteLine("체결 시간 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 20) + "출력 시간 : " + DateTime.Now + ", Insert 되는 시간 : " + sw.ElapsedMilliseconds.ToString());
                sw.Reset();
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
            for(int i=0; i<stockCodeList.Length-1; i++)
            {
                stockCodeStr += (stockCodeList[i]+";");
                // 한번 등록가능한 종목이 100개 => 100으로 나눴을때 나머지가 99이면 요청
                // 마지막 인덱스에 도달했으면 요청
                if((i % 100 == 99) || (i == (stockCodeList.Length-2)))
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@장내 데이터 호출@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    axKHOpenAPI1.SetRealReg(getScreenNum(), stockCodeStr, "10", "1");
                    stockCodeStr = "";
                }
            }
            Console.WriteLine("================================장내 데이터 요청 끝=======================================");
            for (int i = 0; i < kosdaqCodeList.Length - 1; i++)
            {
                stockCodeStr += (kosdaqCodeList[i] + ";");
                // 한번 등록가능한 종목이 100개 => 100으로 나눴을때 나머지가 99이면 요청
                // 마지막 인덱스에 도달했으면 요청
                if ((i % 100 == 99) || (i == (kosdaqCodeList.Length - 2)))
                {
                    Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@코스닥 호출@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                    axKHOpenAPI1.SetRealReg(getScreenNum(), stockCodeStr, "10", "1");
                    stockCodeStr = "";
                }
            }
            Console.WriteLine("================================장내 데이터 요청 끝=======================================");
        }


        // 전종목에 대한 종목코드 가져오기
        private void getStockCode()
        {
            // 종목코드
            string stockCodeListStr = axKHOpenAPI1.GetCodeListByMarket("0"); // 장내
            string kosdaqCodeListStr = axKHOpenAPI1.GetCodeListByMarket("10"); // 코스닥
            stockCodeList = stockCodeListStr.Split(';');
            kosdaqCodeList = kosdaqCodeListStr.Split(';');

            // 디비에서 종목 가져오기 -> 해쉬테이블에 저장
            Hashtable hashStockCode = new Hashtable();
            dbConnect();
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
            for (int i = 0; i < kosdaqCodeList.Length - 1; i++)
            {
                if (!hashStockCode.ContainsKey(kosdaqCodeList[i]))
                {
                    // 디비에 종목코드가 없다면 insert 해준다.
                    Console.WriteLine("종목 코드 : " + kosdaqCodeList[i] + ", 종목명 : " + axKHOpenAPI1.GetMasterCodeName(kosdaqCodeList[i]));
                    stockDBInesrt(kosdaqCodeList[i], axKHOpenAPI1.GetMasterCodeName(kosdaqCodeList[i]));
                }
            }
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
