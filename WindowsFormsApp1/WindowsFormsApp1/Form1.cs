using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            firstChart.Series["Series1"].CustomProperties = "PriceDownColor=Blue, PriceUpColor=Red";

            // Button Click Event
            chartRequestButton.Click += Button_Click;

            // MenuItem Click Event
            로그인MenuItem.Click += MenuItem_Click;

            // chart view Event
            firstChart.AxisViewChanged += Chart_AxisViewChanged;

            // API Event
            axKHOpenAPI1.OnReceiveTrData += AxKHOpenAPI1_OnReceiveTrData;
        }

        public void Chart_AxisViewChanged(object sender, ViewEventArgs e)
        {
            if (sender.Equals(firstChart))
            {
                int startPosition = (int)e.Axis.ScaleView.ViewMinimum;
                int endPosition = (int)e.Axis.ScaleView.ViewMaximum;

                double yMinValue = double.MaxValue;
                double yMaxValue = double.MinValue;

                Series s = firstChart.Series["Series1"];

                for (int i = startPosition; i < endPosition; i++)
                {
                    if (i < s.Points.Count)
                    {
                        yMinValue = Math.Min(yMinValue, s.Points[i].YValues[0]);
                        yMaxValue = Math.Max(yMaxValue, s.Points[i].YValues[1]);
                    }
                }

                firstChart.ChartAreas["ChartArea1"].AxisY.Maximum = yMaxValue;
                firstChart.ChartAreas["ChartArea1"].AxisY.Minimum = yMinValue;


            }
        }

        public void AxKHOpenAPI1_OnReceiveTrData(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnReceiveTrDataEvent e)
        {
            if (e.sRQName.Equals("분봉차트조회"))
            {
                int count = axKHOpenAPI1.GetRepeatCnt(e.sTrCode, e.sRQName);

                firstChart.Series["Series1"].Points.Clear();

                for (int i = 0; i < count; i++)
                {
                    long 현재가 = Math.Abs(long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "현재가")));
                    long 시가 = Math.Abs(long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "시가")));
                    long 고가 = Math.Abs(long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "고가")));
                    long 저가 = Math.Abs(long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "저가")));
                    long 거래량 = long.Parse(axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "거래량"));
                    string 체결시간 = axKHOpenAPI1.GetCommData(e.sTrCode, e.sRQName, i, "체결시간").Trim();

                    int index = firstChart.Series["Series1"].Points.AddXY(체결시간, 고가);
                    firstChart.Series["Series1"].Points[index].YValues[1] = 저가;
                    firstChart.Series["Series1"].Points[index].YValues[2] = 시가;
                    firstChart.Series["Series1"].Points[index].YValues[3] = 현재가;

                    if (시가 < 현재가)
                    {
                        firstChart.Series["Series1"].Points[index].Color = Color.Red;
                        firstChart.Series["Series1"].Points[index].BorderColor = Color.Red;
                    }
                    else if (시가 < 현재가)
                    {
                        firstChart.Series["Series1"].Points[index].Color = Color.Blue;
                        firstChart.Series["Series1"].Points[index].BorderColor = Color.Blue;
                    }
                }
            }
        }

        public void Button_Click(object sender, EventArgs e)
        {
            if (sender.Equals(chartRequestButton))
            {
                if (axKHOpenAPI1.GetConnectState() == 1)
                {
                    string itemCode = itemCodeTextBox.Text;
                    if (itemCode.Length > 0)
                    {
                        axKHOpenAPI1.SetInputValue("종목코드", itemCode);
                        axKHOpenAPI1.SetInputValue("틱범위", "3");
                        axKHOpenAPI1.SetInputValue("수정주가구분", "0");

                        axKHOpenAPI1.CommRqData("분봉차트조회", "opt10080", 0, "1080");
                    }

                }
                else
                {
                    MessageBox.Show("로그인이 필요한 기능입니다.");
                }
            }
        }

        public void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender.Equals(로그인MenuItem))
            {
                axKHOpenAPI1.CommConnect();
            }
        }


    }
}
