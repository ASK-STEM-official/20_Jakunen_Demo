namespace SO_OMS.Presentation.Forms
{
    partial class ProductListForm
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
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            this.textBoxProductID = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.checkBoxIsPublished = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelCount = new System.Windows.Forms.Label();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDesc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPublished = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxProductName.Location = new System.Drawing.Point(59, 26);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(100, 19);
            this.textBoxProductName.TabIndex = 0;
            // 
            // textBoxProductID
            // 
            this.textBoxProductID.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBoxProductID.Location = new System.Drawing.Point(59, 61);
            this.textBoxProductID.Name = "textBoxProductID";
            this.textBoxProductID.Size = new System.Drawing.Size(100, 19);
            this.textBoxProductID.TabIndex = 1;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(184, 59);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCategory.TabIndex = 2;
            this.comboBoxCategory.Text = "カテゴリ";
            // 
            // checkBoxIsPublished
            // 
            this.checkBoxIsPublished.AutoSize = true;
            this.checkBoxIsPublished.Location = new System.Drawing.Point(332, 61);
            this.checkBoxIsPublished.Name = "checkBoxIsPublished";
            this.checkBoxIsPublished.Size = new System.Drawing.Size(105, 16);
            this.checkBoxIsPublished.TabIndex = 3;
            this.checkBoxIsPublished.Text = "出品中のみ表示";
            this.checkBoxIsPublished.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "検索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.ProductCategory,
            this.ProductDesc,
            this.ProductPrice,
            this.ProductStock,
            this.IsPublished,
            this.ProductDetail});
            this.dataGridView1.Location = new System.Drawing.Point(12, 86);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(846, 338);
            this.dataGridView1.TabIndex = 6;
            // 
            // labelCount
            // 
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(823, 64);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(0, 12);
            this.labelCount.TabIndex = 5;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.RegisterButton.Location = new System.Drawing.Point(366, 441);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(105, 31);
            this.RegisterButton.TabIndex = 7;
            this.RegisterButton.Text = "新規登録";
            this.RegisterButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "商品名 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "商品ID :";
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "商品ID";
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "商品名";
            this.ProductName.Name = "ProductName";
            // 
            // ProductCategory
            // 
            this.ProductCategory.DataPropertyName = "Category";
            this.ProductCategory.HeaderText = "商品カテゴリ";
            this.ProductCategory.Name = "ProductCategory";
            this.ProductCategory.ReadOnly = true;
            // 
            // ProductDesc
            // 
            this.ProductDesc.DataPropertyName = "Description";
            this.ProductDesc.HeaderText = "説明";
            this.ProductDesc.Name = "ProductDesc";
            this.ProductDesc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDesc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ProductPrice
            // 
            this.ProductPrice.DataPropertyName = "Price";
            this.ProductPrice.HeaderText = "単価";
            this.ProductPrice.Name = "ProductPrice";
            // 
            // ProductStock
            // 
            this.ProductStock.DataPropertyName = "Stock";
            this.ProductStock.HeaderText = "在庫数";
            this.ProductStock.Name = "ProductStock";
            // 
            // IsPublished
            // 
            this.IsPublished.DataPropertyName = "PublishStatus";
            this.IsPublished.HeaderText = "状態";
            this.IsPublished.Name = "IsPublished";
            // 
            // ProductDetail
            // 
            this.ProductDetail.DataPropertyName = "ProductDetail";
            this.ProductDetail.HeaderText = "詳細";
            this.ProductDetail.Name = "ProductDetail";
            this.ProductDetail.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProductDetail.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ProductDetail.Text = "詳細";
            this.ProductDetail.UseColumnTextForButtonValue = true;
            // 
            // ProductListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 480);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxIsPublished);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxProductID);
            this.Controls.Add(this.textBoxProductName);
            this.Name = "ProductListForm";
            this.Text = "商品一覧";
            this.Load += new System.EventHandler(this.ProductListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxProductName;
        private System.Windows.Forms.TextBox textBoxProductID;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.CheckBox checkBoxIsPublished;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCategory;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductDesc;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPublished;
        private System.Windows.Forms.DataGridViewButtonColumn ProductDetail;
    }
}