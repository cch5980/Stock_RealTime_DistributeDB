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
        private int screenNum = 1000;   // 스크린 번호
        private string[] stockCodeArr;  // 종목코드(장내, 코스닥) 배열
        private StreamWriter writer;    // 파일 쓰기 객체
        private Background1 bw;         // 백그라운드 작업 객체
        private int cheCount_Total;         // 전종목 전체 체결수
        private int cheCount_Today;         // 전종목 금일 체결수
        private DB_Query db_query = new DB_Query(DB_Config.GetDBConnection()); // 디비 Query 객체
        private Dictionary<string, int[]> dictStockCheCount = new Dictionary<string, int[]>();
        private string selectStockCode; // 종목별 상세 체결데이터를 위한 변수

        public Form1()
        {
            InitializeComponent();
            axKHOpenAPI1.OnEventConnect += API_onEventConnect;
            axKHOpenAPI1.OnReceiveRealData += API_onReceiveData;
            StockSearchButton.Click += stockSearch;
            csvOutputButton.Click += csvWriteCheDataBtnClick;
            axKHOpenAPI1.CommConnect();
        }

        private void processInit()
        {
            // DB 연결
            // db_query.setDBConnection(DB_Config.GetDBConnection());
            cheCount_Total = db_query.Select_CheCount_Total();
            cheCount_Today = db_query.Select_CheCount_Today();
            Console.WriteLine("today : " + cheCount_Today);
            this.AllCheCountLabel.Text = cheCount_Total.ToString();
            this.todayCheCountLabel.Text = cheCount_Today.ToString();

            Boolean isFileExist = false;
            // write 파일 생성
            
            if (File.Exists(@File_Config.file_path + File_Config.file_name + File_Config.file_extension))
            {
                isFileExist = true;
            } else
            {
                db_query.Insert_fileOffset(1, File_Config.file_name);
            }
            FileStream fs = File.Open(@File_Config.file_path + File_Config.file_name + File_Config.file_extension, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            writer = new StreamWriter(fs);
            if (!isFileExist) writer.WriteLine("che_stock_code,che_date,che_time,che_price,che_change,che_change_rate,che_volume,che_cumulative_volume,che_cumulative_amount,che_open,che_high,che_low,che_trans_amount_change,che_vp,che_market_cap");

            for (int i = 0; i < 100; i++)
            {
                DataGridView_StockCheDetail.Rows.Add();
            }

        }

        private void API_onReceiveData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveRealDataEvent e)
        {
            if (e.sRealType == "주식체결")
            {
                Console.WriteLine("체결된 종목 명 : " + e.sRealKey);
                // 종목코드, 체결날짜, 체결시간, 현재가, 전일대비, 등락율, 거래량, 누적거래량, 누적거래대금, 시가, 고가, 저가, 거래대금증감, 체결강도, 시가총액
                csvFileWrite(e.sRealKey, DateTime.Now.ToString("yyyy-MM-dd"), axKHOpenAPI1.GetCommRealData(e.sRealKey, 20).Insert(4, ":").Insert(2, ":"), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10), axKHOpenAPI1.GetCommRealData(e.sRealKey, 11), axKHOpenAPI1.GetCommRealData(e.sRealKey, 12), axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 13), axKHOpenAPI1.GetCommRealData(e.sRealKey, 14), axKHOpenAPI1.GetCommRealData(e.sRealKey, 16), axKHOpenAPI1.GetCommRealData(e.sRealKey, 17), axKHOpenAPI1.GetCommRealData(e.sRealKey, 18), axKHOpenAPI1.GetCommRealData(e.sRealKey, 29), axKHOpenAPI1.GetCommRealData(e.sRealKey, 228), axKHOpenAPI1.GetCommRealData(e.sRealKey, 311));

                if (bw != null)
                {
                    this.AllCheCountLabel.Text = (cheCount_Total + bw.getOffset()).ToString();
                    this.todayCheCountLabel.Text = bw.getOffset().ToString();
                    // this.dbInsertWaitCountLabel.Text = bw.getWaitInsertDataCount().ToString();
                }
                // 종목 리스트뷰
                dictStockCheCount[e.sRealKey][0] += 1; dictStockCheCount[e.sRealKey][1] += 1;
                this.DataGridView_StockList.Rows[dictStockCheCount[e.sRealKey][2]].Cells[2].Value = (dictStockCheCount[e.sRealKey][0]);
                this.DataGridView_StockList.Rows[dictStockCheCount[e.sRealKey][2]].Cells[3].Value = (dictStockCheCount[e.sRealKey][1]);

                if(selectStockCode == e.sRealKey)
                {
                    // 종목 상세뷰
                    string che_time = axKHOpenAPI1.GetCommRealData(e.sRealKey, 20);
                    // Console.WriteLine(che_time);
                    // Console.WriteLine(DateTime.ParseExact(DateTime.Now.ToString("yyyy-MM-dd tt ") + che_time.Substring(0, 2) + ":" + che_time.Substring(2, 2) + ":" + che_time.Substring(4, 2), "yyyy-MM-dd tt hh:mm:ss", null));
                    this.DataGridView_StockCheDetail.Rows.Insert(0, che_time, axKHOpenAPI1.GetCommRealData(e.sRealKey, 15), axKHOpenAPI1.GetCommRealData(e.sRealKey, 10));
                    this.DataGridView_StockCheDetail.Rows.RemoveAt(DataGridView_StockCheDetail.Rows.Count - 1);
                }
            }
        }

        private void API_onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if (e.nErrCode == 0)
            {
                Console.WriteLine("로그인 성공");
                processInit(); // 초기 작업

                getStockCode();
                stockReaTimeDataRequest();

                bw = new Background1();
                bw.setOffset(db_query.Select_fileOffset(File_Config.file_name));
                Thread t2 = new Thread(new ThreadStart(bw.ReadAndInsert));
                t2.IsBackground = true;
                t2.Start();
            }
            else
            {
                Console.WriteLine("로그인 실패");
            }
        }


        private void csvFileWrite(string che_stock_code, string che_date, string che_time, string che_price, string che_change, string che_change_rate, string che_volume, string che_cumulative_volume, string che_cumulative_amount, string che_open, string che_high, string che_low, string che_trans_amount_change, string che_vp, string che_market_cap)
        {
            writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", che_stock_code, che_date, che_time, che_price, che_change, che_change_rate, che_volume, che_cumulative_volume, che_cumulative_amount, che_open, che_high, che_low, che_trans_amount_change, che_vp, che_market_cap);
        }


        private void stockSearch(Object sender, EventArgs e)
        {
            DataGridView_StockList.Rows.Clear();
            string searchStockTitle = StockSearchTextBox.Text;
            Console.WriteLine("검색명 : " + searchStockTitle);
            if (searchStockTitle.Length == 0)
            {
                for (int i = 0; i < stockCodeArr.Length; i++)
                {
                    DataGridView_StockList.Rows.Add();
                    DataGridView_StockList["DataGrid_StockCode", i].Value = stockCodeArr[i];
                    DataGridView_StockList["DataGrid_StockName", i].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]);
                    DataGridView_StockList["DataGrid_TotalChe", i].Value = dictStockCheCount[stockCodeArr[i]][0];
                    DataGridView_StockList["DataGrid_TodayChe", i].Value = dictStockCheCount[stockCodeArr[i]][1];
                }
            }
            else
            {
                int idx = 0;
                for (int i = 0; i < stockCodeArr.Length; i++)
                {
                    if (stockCodeArr[i].Contains(searchStockTitle) || axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]).Contains(searchStockTitle))
                    {
                        DataGridView_StockList.Rows.Add();
                        DataGridView_StockList["DataGrid_StockCode", idx].Value = stockCodeArr[i];
                        DataGridView_StockList["DataGrid_StockName", idx].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]);
                        DataGridView_StockList["DataGrid_TotalChe", idx].Value = dictStockCheCount[stockCodeArr[i]][0];
                        DataGridView_StockList["DataGrid_TodayChe", idx].Value = dictStockCheCount[stockCodeArr[i]][1];
                        idx++;
                    }
                }
            }
        }

        private void stockReaTimeDataRequest()
        {
            // 실시간 연결 요청
            string stockCodeStr = "";
            for (int i = 0; i < stockCodeArr.Length; i++)
            {
                stockCodeStr += (stockCodeArr[i] + ";");
                // 한번 등록가능한 종목이 100개 => 100으로 나눴을때 나머지가 99이면 요청
                // 마지막 인덱스에 도달했으면 요청
                if ((i % 100 == 99) || (i == (stockCodeArr.Length - 1)))
                {
                    Console.WriteLine(i + "번째까지의 장내 데이터 호출");
                    axKHOpenAPI1.SetRealReg(getScreenNum(), stockCodeStr, "10", "1");
                    stockCodeStr = "";
                }
            }
        }

        // 전종목에 대한 종목코드 가져오기
        public void getStockCode()
        {
            // 종목코드
            string stockCodeListStr = axKHOpenAPI1.GetCodeListByMarket("0") + axKHOpenAPI1.GetCodeListByMarket("10"); // 장내 + 코스닥
            stockCodeArr = stockCodeListStr.Substring(0, stockCodeListStr.Length - 1).Split(';');

            // 디비에서 종목 가져오기 -> 해쉬테이블에 저장
            Hashtable hashStockCode = db_query.Select_All_StockCode();
            Hashtable hashStockCheCount_total = db_query.Select_CheCountByStockCode_Total();
            Hashtable hashStockCheCount_today = db_query.Select_CheCountByStockCode_Today();

            // API종목과 디비 종목 비교
            for (int i = 0; i < stockCodeArr.Length; i++)
            {
                dictStockCheCount.Add(stockCodeArr[i], new int[] { 0, 0, i });  // { 전체체결수, 오늘체결수, DataGridView Row 인덱스 }
                if (!hashStockCode.ContainsKey(stockCodeArr[i]))
                {
                    // 디비에 종목코드가 없다면 insert;
                    db_query.Insert_stockDB(stockCodeArr[i], axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]));
                }
                // winform GridView
                DataGridView_StockList.Rows.Add();
                DataGridView_StockList["DataGrid_StockCode", i].Value = stockCodeArr[i];
                DataGridView_StockList["DataGrid_StockName", i].Value = axKHOpenAPI1.GetMasterCodeName(stockCodeArr[i]);

                if(hashStockCheCount_total.ContainsKey(stockCodeArr[i]))
                {
                    dictStockCheCount[stockCodeArr[i]][0] = int.Parse(hashStockCheCount_total[stockCodeArr[i]].ToString());
                    DataGridView_StockList["DataGrid_TotalChe", i].Value = hashStockCheCount_total[stockCodeArr[i]];
                }
                if(hashStockCheCount_today.ContainsKey(stockCodeArr[i]))
                {
                    dictStockCheCount[stockCodeArr[i]][1] = int.Parse(hashStockCheCount_today[stockCodeArr[i]].ToString());
                    DataGridView_StockList["DataGrid_TodayChe", i].Value = hashStockCheCount_today[stockCodeArr[i]];
                }
            }
        }

        private string getScreenNum()
        {
            screenNum++;
            return screenNum.ToString();
        }



        // CSV 내보내기 이벤트
        private void csvWriteCheDataBtnClick(Object sender, EventArgs e)
        {

            string fileName;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "저장경로를 지정하세요";
            saveFileDialog.OverwritePrompt = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;

                List<string> checkedCheDateList = new List<string>();
                foreach (DataGridViewRow row in DataGridView_StockCheDetail.Rows)
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
                    // DB_Select_csvCheData(checkedCheDateList[i], fileName);
                }
            }


        }

        // 종목 더블클릭 이벤트
        private void StockListDataGridView_DoubleClick(object sender, EventArgs e)
        {
            /*
            string searchStockCode = DataGridView_StockList.CurrentRow.Cells["종목조회_종목코드"].Value.ToString();
            Console.WriteLine("선택된 종목 코드 : " + searchStockCode);
            csvWriteForStockCode = searchStockCode;
            List<string> stockCheDateList = stockCheDateSelect(searchStockCode);
            StockCheDateDataGridView.Rows.Clear();
            for (int i=0; i<stockCheDateList.Count; i++)
            {
                StockCheDateDataGridView.Rows.Add();
                StockCheDateDataGridView["che_date", i].Value = stockCheDateList[i];
            }
            */
        }

        private void DataGridView_StockList_MouseClick(object sender, MouseEventArgs e)
        {
            selectStockCode = DataGridView_StockList.CurrentRow.Cells["DataGrid_StockCode"].Value.ToString();
            List<string[]> stockCheDataList = db_query.Select_CheDataDetail(selectStockCode);
            Console.WriteLine("행 수 : " + DataGridView_StockCheDetail.Rows.Count);
            if(DataGridView_StockCheDetail.Rows.Count == 0)
            {
                for (int i = 0; i < stockCheDataList.Count; i++)
                {
                    DataGridView_StockCheDetail.Rows.Add();
                    DataGridView_StockCheDetail["DataGrid_CheDateTime", i].Value = stockCheDataList[i][0];
                    DataGridView_StockCheDetail["DataGrid_CheVolume", i].Value = stockCheDataList[i][1];
                    DataGridView_StockCheDetail["DataGrid_ChePrice", i].Value = stockCheDataList[i][2];
                }
            } else
            {
                for(int i=0; i<stockCheDataList.Count; i++)
                {
                    DataGridView_StockCheDetail.Rows[i].Cells[0].Value = stockCheDataList[i][0];
                    DataGridView_StockCheDetail.Rows[i].Cells[1].Value = stockCheDataList[i][1];
                    DataGridView_StockCheDetail.Rows[i].Cells[2].Value = stockCheDataList[i][2];
                }

            }
        }
    }
}
