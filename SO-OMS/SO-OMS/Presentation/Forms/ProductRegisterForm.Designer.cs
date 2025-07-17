namespace SO_OMS.Presentation.Forms
{
    partial class ProductRegisterForm
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
            this.checkBoxPublished = new System.Windows.Forms.CheckBox();
            this.numericThreshold = new System.Windows.Forms.NumericUpDown();
            this.numericStock = new System.Windows.Forms.NumericUpDown();
            this.numericPrice = new System.Windows.Forms.NumericUpDown();
            this.labelProductID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.textBoxProductName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxPublished
            // 
            this.checkBoxPublished.AutoSize = true;
            this.checkBoxPublished.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.checkBoxPublished.Location = new System.Drawing.Point(468, 176);
            this.checkBoxPublished.Name = "checkBoxPublished";
            this.checkBoxPublished.Size = new System.Drawing.Size(74, 20);
            this.checkBoxPublished.TabIndex = 36;
            this.checkBoxPublished.Text = "出品中";
            this.checkBoxPublished.UseVisualStyleBackColor = true;
            // 
            // numericThreshold
            // 
            this.numericThreshold.Location = new System.Drawing.Point(619, 243);
            this.numericThreshold.Name = "numericThreshold";
            this.numericThreshold.Size = new System.Drawing.Size(120, 19);
            this.numericThreshold.TabIndex = 25;
            // 
            // numericStock
            // 
            this.numericStock.Location = new System.Drawing.Point(618, 117);
            this.numericStock.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericStock.Name = "numericStock";
            this.numericStock.Size = new System.Drawing.Size(120, 19);
            this.numericStock.TabIndex = 24;
            // 
            // numericPrice
            // 
            this.numericPrice.Location = new System.Drawing.Point(618, 52);
            this.numericPrice.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericPrice.Name = "numericPrice";
            this.numericPrice.Size = new System.Drawing.Size(120, 19);
            this.numericPrice.TabIndex = 23;
            // 
            // labelProductID
            // 
            this.labelProductID.AutoSize = true;
            this.labelProductID.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.labelProductID.Location = new System.Drawing.Point(165, 55);
            this.labelProductID.Name = "labelProductID";
            this.labelProductID.Size = new System.Drawing.Size(53, 16);
            this.labelProductID.TabIndex = 35;
            this.labelProductID.Text = "商品ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label8.Location = new System.Drawing.Point(465, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "在庫アラート閾値 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label6.Location = new System.Drawing.Point(465, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "在庫数 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label5.Location = new System.Drawing.Point(465, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 32;
            this.label5.Text = "単価 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label4.Location = new System.Drawing.Point(62, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 31;
            this.label4.Text = "商品説明:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label3.Location = new System.Drawing.Point(62, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 30;
            this.label3.Text = "商品カテゴリ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label2.Location = new System.Drawing.Point(62, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "商品名 :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.label1.Location = new System.Drawing.Point(62, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 28;
            this.label1.Text = "商品ID :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonCancel.Location = new System.Drawing.Point(433, 364);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(106, 34);
            this.buttonCancel.TabIndex = 27;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.buttonRegister.Location = new System.Drawing.Point(252, 364);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(106, 34);
            this.buttonRegister.TabIndex = 26;
            this.buttonRegister.Text = "登録";
            this.buttonRegister.UseVisualStyleBackColor = true;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(168, 209);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(229, 106);
            this.textBoxDescription.TabIndex = 22;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Location = new System.Drawing.Point(168, 159);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(121, 20);
            this.comboBoxCategory.TabIndex = 21;
            // 
            // textBoxProductName
            // 
            this.textBoxProductName.Location = new System.Drawing.Point(168, 103);
            this.textBoxProductName.Name = "textBoxProductName";
            this.textBoxProductName.Size = new System.Drawing.Size(100, 19);
            this.textBoxProductName.TabIndex = 20;
            // 
            // ProductRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBoxPublished);
            this.Controls.Add(this.numericThreshold);
            this.Controls.Add(this.numericStock);
            this.Controls.Add(this.numericPrice);
            this.Controls.Add(this.labelProductID);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.textBoxProductName);
            this.Name = "ProductRegisterForm";
            this.Text = "商品登録";
            ((System.ComponentModel.ISupportInitialize)(this.numericThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxPublished;
        private System.Windows.Forms.NumericUpDown numericThreshold;
        private System.Windows.Forms.NumericUpDown numericStock;
        private System.Windows.Forms.NumericUpDown numericPrice;
        private System.Windows.Forms.Label labelProductID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.TextBox textBoxProductName;
    }
}