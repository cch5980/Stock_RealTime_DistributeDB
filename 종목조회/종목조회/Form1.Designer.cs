namespace 종목조회
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
            this.검색textBox = new System.Windows.Forms.TextBox();
            this.검색button = new System.Windows.Forms.Button();
            this.종목dataGridView = new System.Windows.Forms.DataGridView();
            this.종목조회_종목코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목조회_종목명 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.종목조회tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.등락율label = new System.Windows.Forms.Label();
            this.거래량label = new System.Windows.Forms.Label();
            this.전일대비label = new System.Windows.Forms.Label();
            this.현재가label = new System.Windows.Forms.Label();
            this.종목이름label = new System.Windows.Forms.Label();
            this.종목명label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.종목dataGridView)).BeginInit();
            this.종목조회tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // axKHOpenAPI1
            // 
            this.axKHOpenAPI1.Enabled = true;
            this.axKHOpenAPI1.Location = new System.Drawing.Point(656, 388);
            this.axKHOpenAPI1.Name = "axKHOpenAPI1";
            this.axKHOpenAPI1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axKHOpenAPI1.OcxState")));
            this.axKHOpenAPI1.Size = new System.Drawing.Size(100, 50);
            this.axKHOpenAPI1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.검색textBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.검색button, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(105, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(231, 51);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // 검색textBox
            // 
            this.검색textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.검색textBox.Location = new System.Drawing.Point(3, 3);
            this.검색textBox.Name = "검색textBox";
            this.검색textBox.Size = new System.Drawing.Size(109, 25);
            this.검색textBox.TabIndex = 0;
            // 
            // 검색button
            // 
            this.검색button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.검색button.Location = new System.Drawing.Point(118, 3);
            this.검색button.Name = "검색button";
            this.검색button.Size = new System.Drawing.Size(110, 45);
            this.검색button.TabIndex = 1;
            this.검색button.Text = "종목검색";
            this.검색button.UseVisualStyleBackColor = true;
            // 
            // 종목dataGridView
            // 
            this.종목dataGridView.AllowUserToAddRows = false;
            this.종목dataGridView.AllowUserToDeleteRows = false;
            this.종목dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.종목dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.종목조회_종목코드,
            this.종목조회_종목명});
            this.종목dataGridView.Location = new System.Drawing.Point(83, 117);
            this.종목dataGridView.Name = "종목dataGridView";
            this.종목dataGridView.RowHeadersVisible = false;
            this.종목dataGridView.RowHeadersWidth = 51;
            this.종목dataGridView.RowTemplate.Height = 27;
            this.종목dataGridView.Size = new System.Drawing.Size(262, 229);
            this.종목dataGridView.TabIndex = 2;
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
            // 종목조회tableLayoutPanel
            // 
            this.종목조회tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.종목조회tableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.종목조회tableLayoutPanel.ColumnCount = 2;
            this.종목조회tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.종목조회tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.종목조회tableLayoutPanel.Controls.Add(this.등락율label, 1, 4);
            this.종목조회tableLayoutPanel.Controls.Add(this.거래량label, 1, 3);
            this.종목조회tableLayoutPanel.Controls.Add(this.전일대비label, 1, 2);
            this.종목조회tableLayoutPanel.Controls.Add(this.현재가label, 1, 1);
            this.종목조회tableLayoutPanel.Controls.Add(this.종목이름label, 1, 0);
            this.종목조회tableLayoutPanel.Controls.Add(this.종목명label, 0, 0);
            this.종목조회tableLayoutPanel.Controls.Add(this.label2, 0, 2);
            this.종목조회tableLayoutPanel.Controls.Add(this.label1, 0, 1);
            this.종목조회tableLayoutPanel.Controls.Add(this.label3, 0, 3);
            this.종목조회tableLayoutPanel.Controls.Add(this.label4, 0, 4);
            this.종목조회tableLayoutPanel.Location = new System.Drawing.Point(431, 97);
            this.종목조회tableLayoutPanel.Name = "종목조회tableLayoutPanel";
            this.종목조회tableLayoutPanel.RowCount = 5;
            this.종목조회tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.종목조회tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.종목조회tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.종목조회tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.종목조회tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.종목조회tableLayoutPanel.Size = new System.Drawing.Size(248, 249);
            this.종목조회tableLayoutPanel.TabIndex = 3;
            // 
            // 등락율label
            // 
            this.등락율label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.등락율label.AutoSize = true;
            this.등락율label.Location = new System.Drawing.Point(127, 197);
            this.등락율label.Name = "등락율label";
            this.등락율label.Size = new System.Drawing.Size(117, 51);
            this.등락율label.TabIndex = 9;
            this.등락율label.Text = "label";
            this.등락율label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 거래량label
            // 
            this.거래량label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.거래량label.AutoSize = true;
            this.거래량label.Location = new System.Drawing.Point(127, 148);
            this.거래량label.Name = "거래량label";
            this.거래량label.Size = new System.Drawing.Size(117, 48);
            this.거래량label.TabIndex = 8;
            this.거래량label.Text = "label";
            this.거래량label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 전일대비label
            // 
            this.전일대비label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.전일대비label.AutoSize = true;
            this.전일대비label.Location = new System.Drawing.Point(127, 99);
            this.전일대비label.Name = "전일대비label";
            this.전일대비label.Size = new System.Drawing.Size(117, 48);
            this.전일대비label.TabIndex = 7;
            this.전일대비label.Text = "label";
            this.전일대비label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 현재가label
            // 
            this.현재가label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.현재가label.AutoSize = true;
            this.현재가label.Location = new System.Drawing.Point(127, 50);
            this.현재가label.Name = "현재가label";
            this.현재가label.Size = new System.Drawing.Size(117, 48);
            this.현재가label.TabIndex = 6;
            this.현재가label.Text = "label";
            this.현재가label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 종목이름label
            // 
            this.종목이름label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.종목이름label.AutoSize = true;
            this.종목이름label.Location = new System.Drawing.Point(127, 1);
            this.종목이름label.Name = "종목이름label";
            this.종목이름label.Size = new System.Drawing.Size(117, 48);
            this.종목이름label.TabIndex = 5;
            this.종목이름label.Text = "label";
            this.종목이름label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // 종목명label
            // 
            this.종목명label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.종목명label.AutoSize = true;
            this.종목명label.Location = new System.Drawing.Point(4, 1);
            this.종목명label.Name = "종목명label";
            this.종목명label.Size = new System.Drawing.Size(116, 48);
            this.종목명label.TabIndex = 0;
            this.종목명label.Text = "종목이름";
            this.종목명label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 48);
            this.label2.TabIndex = 2;
            this.label2.Text = "전일대비";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "현재가";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 48);
            this.label3.TabIndex = 3;
            this.label3.Text = "거래량";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 51);
            this.label4.TabIndex = 4;
            this.label4.Text = "등락율";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.종목조회tableLayoutPanel);
            this.Controls.Add(this.종목dataGridView);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.axKHOpenAPI1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.axKHOpenAPI1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.종목dataGridView)).EndInit();
            this.종목조회tableLayoutPanel.ResumeLayout(false);
            this.종목조회tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxKHOpenAPILib.AxKHOpenAPI axKHOpenAPI1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox 검색textBox;
        private System.Windows.Forms.Button 검색button;
        private System.Windows.Forms.DataGridView 종목dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목조회_종목코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 종목조회_종목명;
        private System.Windows.Forms.TableLayoutPanel 종목조회tableLayoutPanel;
        private System.Windows.Forms.Label 종목이름label;
        private System.Windows.Forms.Label 종목명label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label 등락율label;
        private System.Windows.Forms.Label 거래량label;
        private System.Windows.Forms.Label 전일대비label;
        private System.Windows.Forms.Label 현재가label;
    }
}

