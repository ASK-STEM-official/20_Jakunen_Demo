using System;
using System.Windows.Forms;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Presentation.Forms
{
    public partial class ProductRegisterForm : Form
    {
        private readonly IProductRepository _productRepository;

        public ProductRegisterForm(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
            Load += ProductRegisterForm_Load;
            buttonRegister.Click += buttonRegister_Click;
            buttonCancel.Click += (s, e) => Close();
        }

        private void ProductRegisterForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add(new ComboBoxItem("食品", 1));
            comboBoxCategory.Items.Add(new ComboBoxItem("雑貨", 2));
            comboBoxCategory.Items.Add(new ComboBoxItem("その他", 3));
            comboBoxCategory.SelectedIndex = 0;

            numericPrice.Maximum = 999999;
            numericStock.Maximum = 999999;
            numericThreshold.Maximum = 999999;

            checkBoxPublished.Checked = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var newProduct = new Product
            {
                ProductName = textBoxProductName.Text.Trim(),
                Description = textBoxDescription.Text.Trim(),
                Price = numericPrice.Value,
                Stock = (int)numericStock.Value,
                AlertThreshold = (int?)numericThreshold.Value,
                IsPublished = checkBoxPublished.Checked,
                CategoryID = (comboBoxCategory.SelectedItem as ComboBoxItem)?.Value ?? 3
            };

            try
            {
                _productRepository.Insert(newProduct);
                MessageBox.Show("商品を登録しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
            {
                MessageBox.Show("商品名は必須です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericPrice.Value <= 0)
            {
                MessageBox.Show("価格は1円以上を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericStock.Value < 0)
            {
                MessageBox.Show("在庫数は0以上を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (numericThreshold.Value < 0)
            {
                MessageBox.Show("在庫アラートしきい値は0以上を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private class ComboBoxItem
        {
            public string Display { get; }
            public int Value { get; }

            public ComboBoxItem(string display, int value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString() => Display;
        }
    }
}
