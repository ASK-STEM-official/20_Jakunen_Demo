using System;
using System.Windows.Forms;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Presentation.Forms
{
    public partial class ProductDetailForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly Product _product;

        public ProductDetailForm(IProductRepository productRepository, Product product)
        {
            InitializeComponent();
            _productRepository = productRepository;
            _product = product;
            Load += ProductDetailForm_Load;
        }

        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            // 初期表示
            labelProductID.Text = _product.ProductID.ToString();
            textBoxProductName.Text = _product.ProductName;
            textBoxDescription.Text = _product.Description;
            numericPrice.Value = _product.Price;
            numericStock.Value = _product.Stock;
            numericThreshold.Value = _product.AlertThreshold ?? 0;
            checkBoxPublished.Checked = _product.IsPublished;

            // カテゴリ
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add(new ComboBoxItem("食品", 1));
            comboBoxCategory.Items.Add(new ComboBoxItem("雑貨", 2));
            comboBoxCategory.Items.Add(new ComboBoxItem("その他", 99));

            foreach (ComboBoxItem item in comboBoxCategory.Items)
            {
                if (item.Value == _product.CategoryID)
                {
                    comboBoxCategory.SelectedItem = item;
                    break;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
            {
                MessageBox.Show("商品名は必須です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _product.ProductName = textBoxProductName.Text.Trim();
            _product.Description = textBoxDescription.Text.Trim();
            _product.Price = numericPrice.Value;
            _product.Stock = (int)numericStock.Value;
            _product.AlertThreshold = (int?)numericThreshold.Value;
            _product.IsPublished = checkBoxPublished.Checked;
            _product.CategoryID = (comboBoxCategory.SelectedItem as ComboBoxItem)?.Value ?? 99;

            try
            {
                _productRepository.Update(_product);
                MessageBox.Show("商品情報を更新しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
