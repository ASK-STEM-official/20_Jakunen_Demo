using SO_OMS.Application.Usecases;
using SO_OMS.Domain.Utils;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Windows.Forms;
using System.Linq;

namespace SO_OMS.Presentation.Forms
{
    public partial class ProductDetailForm : Form
    {
        private readonly ProductDetailViewModel _viewModel;
        private readonly UpdateProductUseCase _updateUseCase;

        public ProductDetailForm(ProductDetailViewModel viewModel, UpdateProductUseCase updateUseCase)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _updateUseCase = updateUseCase;

            Load += ProductDetailForm_Load;
            buttonSave.Click += buttonSave_Click;
            buttonClose.Click += buttonClose_Click;
        }

        private void ProductDetailForm_Load(object sender, EventArgs e)
        {
            Text = _viewModel.Title;

            labelProductID.Text = _viewModel.Product.ProductID.ToString();
            textBoxProductName.Text = _viewModel.Product.ProductName;
            textBoxDescription.Text = _viewModel.Product.Description;
            numericPrice.Value = _viewModel.Product.Price;
            numericStock.Value = _viewModel.Product.Stock;
            numericThreshold.Value = _viewModel.Product.AlertThreshold ?? 0;
            checkBoxPublished.Checked = _viewModel.Product.IsPublished;

            comboBoxCategory.DataSource = CategoryResolver.GetAll().ToList();
            comboBoxCategory.DisplayMember = "Value";
            comboBoxCategory.ValueMember = "Key";

            comboBoxCategory.SelectedValue = CategoryResolver.GetId(_viewModel.Product.Category);
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            _viewModel.UpdateFromForm(
                textBoxProductName.Text.Trim(),
                textBoxDescription.Text.Trim(),
                numericPrice.Value,
                (int)numericStock.Value,
                checkBoxPublished.Checked
            );
            _viewModel.Product.AlertThreshold = (int?)numericThreshold.Value;
            _viewModel.Product.Category = CategoryResolver.GetName((int)comboBoxCategory.SelectedValue);


            try
            {
                _updateUseCase.Execute(_viewModel.Product);
                MessageBox.Show("商品情報を更新しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(textBoxProductName.Text))
            {
                MessageBox.Show("商品名は必須です。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numericPrice.Value <= 0)
            {
                MessageBox.Show("価格は1円以上で入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
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

        private void label6_Click(object sender, EventArgs e) { }
        private void textBoxDescription_TextChanged(object sender, EventArgs e) { }
    }
}
