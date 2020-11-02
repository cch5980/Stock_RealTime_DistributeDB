using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 로그인사용자
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoginButton.Click += loginButton;
            axKHOpenAPI1.OnEventConnect += onEventConnect;
        }

        private void loginButton(object sender, EventArgs e)
        {
            axKHOpenAPI1.CommConnect();
        }

        public void onEventConnect(object sender, AxKHOpenAPILib._DKHOpenAPIEvents_OnEventConnectEvent e)
        {
            if(e.nErrCode == 0)
            {
                string 계좌목록 = axKHOpenAPI1.GetLoginInfo("ACCLIST").Trim();
                string[] 사용자계좌 = 계좌목록.Split(';');

                for(int i=0; i<사용자계좌.Length; i++)
                {
                    AccountList.Items.Add(사용자계좌[i]);
                }
                string 사용자id = axKHOpenAPI1.GetLoginInfo("USER_ID");
                UserId.Text = 사용자id;

                string 사용자이름 = axKHOpenAPI1.GetLoginInfo("USER_NAME");
                UserName.Text = 사용자이름;

                string 접속서버구분 = axKHOpenAPI1.GetLoginInfo("GetServerGubun");
                GetServer.Text = 접속서버구분;
            }
        }

    }
}
