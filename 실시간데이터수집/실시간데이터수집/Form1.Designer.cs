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
            this.axKHOpenAPI1 = new AxKHOpenAPILib.AxKHOpenAPI();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StockSearchTextBox = new System.Windows.Forms.TextBox();
            this.StockSearchButton = new System.Windows.Forms.Button();
            this.StockListDataGridView = new System.Windows.Forms.DataGridView();
            this.종목조회_종목코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목조회_종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockCheDateDataGridView = new System.Windows.Forms.DataGridView();
            this.che_date_check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.che_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.csvOutputButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCheDateDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(769, 474);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(66, 24);
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
            // StockListDataGridView
            // 
            this.StockListDataGridView.AllowUserToAddRows = false;
            this.StockListDataGridView.AllowUserToDeleteRows = false;
            this.StockListDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockListDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목조회_종목코드,
            this.종목조회_종목명});
            this.StockListDataGridView.Location = new System.Drawing.Point(12, 81);
            this.StockListDataGridView.Name = "StockListDataGridView";
            this.StockListDataGridView.RowHeadersVisible = false;
            this.StockListDataGridView.RowHeadersWidth = 51;
            this.StockListDataGridView.RowTemplate.Height = 27;
            this.StockListDataGridView.Size = new System.Drawing.Size(379, 404);
            this.StockListDataGridView.TabIndex = 2;
            this.StockListDataGridView.DoubleClick += new System.EventHandler(this.StockListDataGridView_DoubleClick);
            // 
            // 종목조회_종목코드
            // 
            this.종목조회_종목코드.HeaderText = "종목코드";
            this.종목조회_종목코드.MinimumWidth = 6;
            this.종목조회_종목코드.Name = "종목조회_종목코드";
            this.종목조회_종목코드.ReadOnly = true;
            this.종목조회_종목코드.Width = 125;
            // 
            // 종목조회_종목명
            // 
            this.종목조회_종목명.HeaderText = "종목명";
            this.종목조회_종목명.MinimumWidth = 6;
            this.종목조회_종목명.Name = "종목조회_종목명";
            this.종목조회_종목명.ReadOnly = true;
            this.종목조회_종목명.Width = 125;
            // 
            // StockCheDateDataGridView
            // 
            this.StockCheDateDataGridView.AllowUserToAddRows = false;
            this.StockCheDateDataGridView.AllowUserToDeleteRows = false;
            this.StockCheDateDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StockCheDateDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.StockCheDateDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.che_date_check,
            this.che_date});
            this.StockCheDateDataGridView.Location = new System.Drawing.Point(453, 99);
            this.StockCheDateDataGridView.Name = "StockCheDateDataGridView";
            this.StockCheDateDataGridView.RowHeadersVisible = false;
            this.StockCheDateDataGridView.RowHeadersWidth = 51;
            this.StockCheDateDataGridView.RowTemplate.Height = 27;
            this.StockCheDateDataGridView.Size = new System.Drawing.Size(314, 352);
            this.StockCheDateDataGridView.TabIndex = 3;
            // 
            // che_date_check
            // 
            this.che_date_check.HeaderText = "선택";
            this.che_date_check.MinimumWidth = 6;
            this.che_date_check.Name = "che_date_check";
            this.che_date_check.Width = 125;
            // 
            // che_date
            // 
            this.che_date.HeaderText = "체결일자";
            this.che_date.MinimumWidth = 6;
            this.che_date.Name = "che_date";
            this.che_date.ReadOnly = true;
            this.che_date.Width = 125;
            // 
            // csvOutputButton
            // 
            this.csvOutputButton.Location = new System.Drawing.Point(540, 40);
            this.csvOutputButton.Name = "csvOutputButton";
            this.csvOutputButton.Size = new System.Drawing.Size(133, 23);
            this.csvOutputButton.TabIndex = 4;
            this.csvOutputButton.Text = "CSV로 내보내기";
            this.csvOutputButton.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 497);
            this.Controls.Add(this.csvOutputButton);
            this.Controls.Add(this.StockCheDateDataGridView);
            this.Controls.Add(this.StockListDataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StockListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StockCheDateDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox StockSearchTextBox;
        private System.Windows.Forms.Button StockSearchButton;
        private System.Windows.Forms.DataGridView StockListDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목조회_종목코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목조회_종목명;
        private System.Windows.Forms.DataGridView StockCheDateDataGridView;
        private System.Windows.Forms.Button csvOutputButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn che_date_check;
        private System.Windows.Forms.DataGridViewTextBoxColumn che_date;
    }
}

