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


namespace 실시간데이터수집
{
    public partial class Form1 : Form
    {
        int screenNum = 1000;
        string[] stockCodeList;
        string[] kosdaqCodeList;
        public Form1()
        {
            InitializeComponent();

            // axKHOpenAPI1.OnEventConnect += API_onEventConnect;
            // axKHOpenAPI1.OnReceiveRealData += API_onReceiveData;

            // axKHOpenAPI1.CommConnect();
            testInsert();
        }

        private void API_onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                Console.WriteLine("로그인 성공");
                getStockCode();
                // dataRequest();
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
                Console.WriteLine("종목 코드 : " + e.sRealKey + ", 현재가 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 10) + ", 체결시간 : " + axKHOpenAPI1.GetCommRealData(e.sRealKey, 20));
                // DB 삽입
                realtimeStockDataDBInsert(e.sRealKey, axKHOpenAPI1.GetCommRealData(e.sRealKey, 20), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10), axKHOpenAPI1.GetCommRealData(e.sRealKey, 11), axKHOpenAPI1.GetCommRealData(e.sRealKey, 12), axKHOpenAPI1.GetCommRealData(e.sRealKey, 27), axKHOpenAPI1.GetCommRealData(e.sRealKey, 28), axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 13));
            }
            else
            {
                // Console.WriteLine("타입 : " + e.sRealType);
            }
        }

        private void testInsert()
        {
            // 날짜 변환
            string dateStr = "144331";
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = Int32.Parse(dateStr.Substring(0, 2));
            int minute = Int32.Parse(dateStr.Substring(2, 2));
            int second = Int32.Parse(dateStr.Substring(4, 2));

            DateTime date = new DateTime(year, month, day, hour, minute, second);
            Console.WriteLine(date.ToString());

            string result = DateTime.Parse(date.ToString(), new System.Globalization.CultureInfo("ko-KR", true)).ToString("yyyy-MM-dd HH:mm:ss");

            // DateTime result = DateTime.ParseExact(date.ToString(), "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
            Console.WriteLine("result : " + result);
            Application.Exit();

            
            dbConnect();
            string sql = "insert into realtime_che (STOCK_CODE, realtime_datetime, realtime_price, realtime_yesterday, realtime_fluctutation, realtime_sell, realtime_buy, realtime_volume, realtime_cumul_volume) VALUES ('000545', @realtime_datetime, '-16', '-200', '-1.19', '-16700', '-16600', '-100', '131773')";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@realtime_datetime", DbType.DateTime);
            cmd.Prepare();

            cmd.Parameters[0].Value = result;
            cmd.ExecuteNonQuery();
            dbDisconnect();
            
        }

        private SQLiteConnection conn = null;
        private void dbConnect()
        {
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
        private void realtimeStockDataDBInsert(string stock_code, string realtime_datetime, string realtime_price, string realtime_yesterday, string realtime_fluctutation, string realtime_sell, string realtime_buy, string realtime_volume, string realtime_cumul_volume)
        {
            // STOCK_CODE, realtime_datetime, realtime_price, realtime_yesterday, realtime_fluctutation, realtime_sell, realtime_buy, realtime_volume, realtime_cumul_volume
            string sql = "insert into realtime_che_data (STOCK_CODE, realtime_datetime, realtime_price, realtime_yesterday, realtime_fluctutation, realtime_sell, realtime_buy, realtime_volume, realtime_cumul_volume) VALUES (@STOCK_CODE, @realtime_datetime, @realtime_price, @realtime_yesterday, @realtime_fluctutation, @realtime_sell, @realtime_buy, @realtime_volume, @realtime_cumul_volume)";

            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.Parameters.Add("@STOCK_CODE", DbType.String);
            cmd.Parameters.Add("@realtime_datetime", DbType.String);
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
            Console.WriteLine("DB Insert");
        }

        private void dataRequest()
        {
            // DB연결
            Console.WriteLine("DB 연결");
            dbConnect();

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
            string stockCodeListStr = axKHOpenAPI1.GetCodeListByMarket("0"); // 장내
            string kosdaqCodeListStr = axKHOpenAPI1.GetCodeListByMarket("10"); // 코스닥
            stockCodeList = stockCodeListStr.Split(';');
            kosdaqCodeList = kosdaqCodeListStr.Split(';');

            /*
            dbConnect();
            for (int i = 0; i < stockCodeList.Length - 1; i++)
            {
                Console.WriteLine("종목 코드 : " + stockCodeList[i] + ", 종목명 : " + axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]));
                stockDBInesrt(stockCodeList[i], axKHOpenAPI1.GetMasterCodeName(stockCodeList[i]));
            }
            for (int i=0; i< kosdaqCodeList.Length-1; i++)
            {
                Console.WriteLine("종목 코드 : " + kosdaqCodeList[i] + ", 종목명 : " + axKHOpenAPI1.GetMasterCodeName(kosdaqCodeList[i]));
                stockDBInesrt(kosdaqCodeList[i], axKHOpenAPI1.GetMasterCodeName(kosdaqCodeList[i]));
            }
            dbDisconnect();
            */
        }

        private string getScreenNum()
        {
            screenNum++;
            return screenNum.ToString();
        }
    }
}
