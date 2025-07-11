namespace SO_OMS.Presentation.Forms
{
    partial class DashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsResolved = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.button1.Location = new System.Drawing.Point(31, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 71);
            this.button1.TabIndex = 0;
            this.button1.Text = "商品一覧";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.ProductStock,
            this.IsResolved});
            this.dataGridView1.Location = new System.Drawing.Point(400, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(388, 395);
            this.dataGridView1.TabIndex = 4;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "商品ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            this.ProductID.Width = 70;
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "商品名";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // ProductStock
            // 
            this.ProductStock.DataPropertyName = "ProductStock";
            this.ProductStock.HeaderText = "在庫数";
            this.ProductStock.Name = "ProductStock";
            this.ProductStock.ReadOnly = true;
            this.ProductStock.Width = 70;
            // 
            // IsResolved
            // 
            this.IsResolved.DataPropertyName = "IsResolved";
            this.IsResolved.HeaderText = "対応状況";
            this.IsResolved.Name = "IsResolved";
            this.IsResolved.ReadOnly = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.button2.Location = new System.Drawing.Point(217, 62);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 71);
            this.button2.TabIndex = 5;
            this.button2.Text = "受注一覧";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.button3.Location = new System.Drawing.Point(31, 204);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(143, 71);
            this.button3.TabIndex = 6;
            this.button3.Text = "分析メニュー";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.button4.Location = new System.Drawing.Point(217, 204);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(143, 71);
            this.button4.TabIndex = 7;
            this.button4.Text = "ログアウト";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "DashboardForm";
            this.Text = "ダッシュボード";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductStock;
        private System.Windows.Forms.DataGridViewComboBoxColumn IsResolved;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}