namespace 실시간데이터수집
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StockSearchTextBox = new System.Windows.Forms.TextBox();
            this.StockSearchButton = new System.Windows.Forms.Button();
            this.DataGridView_StockList = new System.Windows.Forms.DataGridView();
            this.DataGrid_StockCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGrid_StockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGrid_TotalChe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGrid_TodayChe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGridView_StockCheDetail = new System.Windows.Forms.DataGridView();
            this.DataGrid_CheDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGrid_CheVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataGrid_ChePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csvOutputButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dbInsertWaitCountLabel = new System.Windows.Forms.Label();
            this.todayCheCountLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AllCheCountLabel = new System.Windows.Forms.Label();
            this.Chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Button_1Min = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_StockList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_StockCheDetail)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(1499, 1);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(74, 27);
            this.axKHOpenAPI1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.StockSearchTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.StockSearchButton, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(593, 26);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(229, 39);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // StockSearchTextBox
            // 
            this.StockSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockSearchTextBox.Location = new System.Drawing.Point(3, 3);
            this.StockSearchTextBox.Name = "StockSearchTextBox";
            this.StockSearchTextBox.Size = new System.Drawing.Size(108, 25);
            this.StockSearchTextBox.TabIndex = 0;
            // 
            // StockSearchButton
            // 
            this.StockSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockSearchButton.Location = new System.Drawing.Point(117, 3);
            this.StockSearchButton.Name = "StockSearchButton";
            this.StockSearchButton.Size = new System.Drawing.Size(109, 33);
            this.StockSearchButton.TabIndex = 1;
            this.StockSearchButton.Text = "종목검색";
            this.StockSearchButton.UseVisualStyleBackColor = true;
            // 
            // DataGridView_StockList
            // 
            this.DataGridView_StockList.AllowUserToAddRows = false;
            this.DataGridView_StockList.AllowUserToDeleteRows = false;
            this.DataGridView_StockList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_StockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_StockList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGrid_StockCode,
            this.DataGrid_StockName,
            this.DataGrid_TotalChe,
            this.DataGrid_TodayChe});
            this.DataGridView_StockList.Location = new System.Drawing.Point(12, 149);
            this.DataGridView_StockList.Name = "DataGridView_StockList";
            this.DataGridView_StockList.RowHeadersVisible = false;
            this.DataGridView_StockList.RowHeadersWidth = 51;
            this.DataGridView_StockList.RowTemplate.Height = 27;
            this.DataGridView_StockList.Size = new System.Drawing.Size(504, 460);
            this.DataGridView_StockList.TabIndex = 2;
            this.DataGridView_StockList.DoubleClick += new System.EventHandler(this.StockListDataGridView_DoubleClick);
            this.DataGridView_StockList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView_StockList_MouseClick);
            // 
            // DataGrid_StockCode
            // 
            this.DataGrid_StockCode.HeaderText = "종목코드";
            this.DataGrid_StockCode.MinimumWidth = 6;
            this.DataGrid_StockCode.Name = "DataGrid_StockCode";
            this.DataGrid_StockCode.ReadOnly = true;
            this.DataGrid_StockCode.Width = 125;
            // 
            // DataGrid_StockName
            // 
            this.DataGrid_StockName.HeaderText = "종목명";
            this.DataGrid_StockName.MinimumWidth = 6;
            this.DataGrid_StockName.Name = "DataGrid_StockName";
            this.DataGrid_StockName.ReadOnly = true;
            this.DataGrid_StockName.Width = 125;
            // 
            // DataGrid_TotalChe
            // 
            this.DataGrid_TotalChe.HeaderText = "전체 체결수";
            this.DataGrid_TotalChe.MinimumWidth = 6;
            this.DataGrid_TotalChe.Name = "DataGrid_TotalChe";
            this.DataGrid_TotalChe.ReadOnly = true;
            this.DataGrid_TotalChe.Width = 125;
            // 
            // DataGrid_TodayChe
            // 
            this.DataGrid_TodayChe.HeaderText = "오늘 체결수";
            this.DataGrid_TodayChe.MinimumWidth = 6;
            this.DataGrid_TodayChe.Name = "DataGrid_TodayChe";
            this.DataGrid_TodayChe.ReadOnly = true;
            this.DataGrid_TodayChe.Width = 125;
            // 
            // DataGridView_StockCheDetail
            // 
            this.DataGridView_StockCheDetail.AllowUserToAddRows = false;
            this.DataGridView_StockCheDetail.AllowUserToDeleteRows = false;
            this.DataGridView_StockCheDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridView_StockCheDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_StockCheDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGrid_CheDateTime,
            this.DataGrid_CheVolume,
            this.DataGrid_ChePrice});
            this.DataGridView_StockCheDetail.Location = new System.Drawing.Point(532, 149);
            this.DataGridView_StockCheDetail.Name = "DataGridView_StockCheDetail";
            this.DataGridView_StockCheDetail.RowHeadersVisible = false;
            this.DataGridView_StockCheDetail.RowHeadersWidth = 51;
            this.DataGridView_StockCheDetail.RowTemplate.Height = 27;
            this.DataGridView_StockCheDetail.Size = new System.Drawing.Size(379, 460);
            this.DataGridView_StockCheDetail.TabIndex = 3;
            // 
            // DataGrid_CheDateTime
            // 
            this.DataGrid_CheDateTime.HeaderText = "체결시간";
            this.DataGrid_CheDateTime.MinimumWidth = 6;
            this.DataGrid_CheDateTime.Name = "DataGrid_CheDateTime";
            this.DataGrid_CheDateTime.ReadOnly = true;
            this.DataGrid_CheDateTime.Width = 125;
            // 
            // DataGrid_CheVolume
            // 
            this.DataGrid_CheVolume.HeaderText = "체결량";
            this.DataGrid_CheVolume.MinimumWidth = 6;
            this.DataGrid_CheVolume.Name = "DataGrid_CheVolume";
            this.DataGrid_CheVolume.ReadOnly = true;
            this.DataGrid_CheVolume.Width = 125;
            // 
            // DataGrid_ChePrice
            // 
            this.DataGrid_ChePrice.HeaderText = "체결가격";
            this.DataGrid_ChePrice.MinimumWidth = 6;
            this.DataGrid_ChePrice.Name = "DataGrid_ChePrice";
            this.DataGrid_ChePrice.ReadOnly = true;
            this.DataGrid_ChePrice.Width = 125;
            // 
            // csvOutputButton
            // 
            this.csvOutputButton.Location = new System.Drawing.Point(647, 93);
            this.csvOutputButton.Name = "csvOutputButton";
            this.csvOutputButton.Size = new System.Drawing.Size(133, 23);
            this.csvOutputButton.TabIndex = 4;
            this.csvOutputButton.Text = "CSV로 내보내기";
            this.csvOutputButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.37523F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.62477F));
            this.tableLayoutPanel2.Controls.Add(this.dbInsertWaitCountLabel, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.todayCheCountLabel, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.AllCheCountLabel, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(504, 122);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // dbInsertWaitCountLabel
            // 
            this.dbInsertWaitCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dbInsertWaitCountLabel.AutoSize = true;
            this.dbInsertWaitCountLabel.Location = new System.Drawing.Point(322, 81);
            this.dbInsertWaitCountLabel.Name = "dbInsertWaitCountLabel";
            this.dbInsertWaitCountLabel.Size = new System.Drawing.Size(178, 40);
            this.dbInsertWaitCountLabel.TabIndex = 5;
            this.dbInsertWaitCountLabel.Text = "0";
            this.dbInsertWaitCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // todayCheCountLabel
            // 
            this.todayCheCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.todayCheCountLabel.AutoSize = true;
            this.todayCheCountLabel.Location = new System.Drawing.Point(322, 41);
            this.todayCheCountLabel.Name = "todayCheCountLabel";
            this.todayCheCountLabel.Size = new System.Drawing.Size(178, 39);
            this.todayCheCountLabel.TabIndex = 4;
            this.todayCheCountLabel.Text = "2";
            this.todayCheCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "DB 내 전종목 체결 수";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 39);
            this.label2.TabIndex = 1;
            this.label2.Text = "당일 전종목 체결 수";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(311, 40);
            this.label3.TabIndex = 2;
            this.label3.Text = "DB Insert 대기중인 레코드 수";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AllCheCountLabel
            // 
            this.AllCheCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllCheCountLabel.AutoSize = true;
            this.AllCheCountLabel.Location = new System.Drawing.Point(322, 1);
            this.AllCheCountLabel.Name = "AllCheCountLabel";
            this.AllCheCountLabel.Size = new System.Drawing.Size(178, 39);
            this.AllCheCountLabel.TabIndex = 3;
            this.AllCheCountLabel.Text = "1";
            this.AllCheCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Chart
            // 
            chartArea1.Name = "ChartArea1";
            this.Chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Chart.Legends.Add(legend1);
            this.Chart.Location = new System.Drawing.Point(946, 159);
            this.Chart.Name = "Chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.Chart.Series.Add(series1);
            this.Chart.Size = new System.Drawing.Size(571, 439);
            this.Chart.TabIndex = 6;
            this.Chart.Text = "chart1";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel3.Controls.Add(this.button6, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.button5, 4, 0);
            this.tableLayoutPanel3.Controls.Add(this.button4, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.Button_1Min, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(965, 109);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(530, 44);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(443, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 38);
            this.button6.TabIndex = 5;
            this.button6.Text = "30분";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(355, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 38);
            this.button5.TabIndex = 4;
            this.button5.Text = "15분";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(267, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(82, 38);
            this.button4.TabIndex = 3;
            this.button4.Text = "10분";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.Location = new System.Drawing.Point(179, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(82, 38);
            this.button3.TabIndex = 2;
            this.button3.Text = "5분";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(91, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 38);
            this.button2.TabIndex = 1;
            this.button2.Text = "3분";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Button_1Min
            // 
            this.Button_1Min.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_1Min.Location = new System.Drawing.Point(3, 3);
            this.Button_1Min.Name = "Button_1Min";
            this.Button_1Min.Size = new System.Drawing.Size(82, 38);
            this.Button_1Min.TabIndex = 0;
            this.Button_1Min.Text = "1분";
            this.Button_1Min.UseVisualStyleBackColor = true;
            this.Button_1Min.Click += new System.EventHandler(this.Button_1Min_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 631);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.Chart);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.csvOutputButton);
            this.Controls.Add(this.DataGridView_StockCheDetail);
            this.Controls.Add(this.DataGridView_StockList);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_StockList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_StockCheDetail)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Chart)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox StockSearchTextBox;
        private System.Windows.Forms.Button StockSearchButton;
        private System.Windows.Forms.DataGridView DataGridView_StockList;
        private System.Windows.Forms.DataGridView DataGridView_StockCheDetail;
        private System.Windows.Forms.Button csvOutputButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label dbInsertWaitCountLabel;
        private System.Windows.Forms.Label todayCheCountLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AllCheCountLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Button_1Min;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_StockCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_StockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_TotalChe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_TodayChe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_CheDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_CheVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataGrid_ChePrice;
    }
}

