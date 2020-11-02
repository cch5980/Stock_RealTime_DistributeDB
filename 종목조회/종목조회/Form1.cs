using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 종목조회
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            axKHOpenAPI1.CommConnect();
            axKHOpenAPI1.OnEventConnect += onEventConnect;
            검색button.Click += stockSearch;
            axKHOpenAPI1.OnReceiveTrData += onReceiveTrData;
        }

        public void onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e )
        {
            if(e.nErrCode == 0)
            {
                string 종목코드리스트 = axKHOpenAPI1.GetCodeListByMarket("0");
                string[] 종목코드 = 종목코드리스트.Split(';');
                for(int i = 0; i < 종목코드.Length; i++)
                {
                    종목dataGridView.Rows.Add();
                    종목dataGridView["종목조회_종목코드", i].Value = 종목코드[i];
                    종목dataGridView["종목조회_종목명", i].Value = axKHOpenAPI1.GetMasterCodeName(종목코드[i]);
                }
            }
        }

        public void stockSearch(object sender, EventArgs e)
        {
            string 종목코드 = 검색textBox.Text;
            if(검색textBox.Text.Length > 0)
            {
                axKHOpenAPI1.SetInputValue("종목코드", 종목코드);
                axKHOpenAPI1.CommRqData("종목정보요청", "opt10001", 0, "5000");

            }
        }

        public void onReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if(e.sRQName == "종목정보요청")
            {
                string 종목이름 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "종목명").Trim();
                long 현재가 = long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "현재가").Trim().Substring(1));
                long 전일대비 = long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "전일대비").Trim());
                long 거래량 = long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "거래량").Trim());
                string 등락율 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, 0, "등락율").Trim();

                종목이름label.Text = 종목이름;
                현재가label.Text = string.Format("{0:#,###}", 현재가);
                전일대비label.Text = string.Format("{0:#,###}", 전일대비);
                거래량label.Text = string.Format("{0:#,###}", 거래량);
                등락율label.Text = 등락율;
            }
        }

    }
}
