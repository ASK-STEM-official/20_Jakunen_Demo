using SO_OMS.Application.Usecases.Products;
using SO_OMS.Domain.Entities;
using SO_OMS.Domain.Utils;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

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
            try
            {
                var product = new Product
                {
                    ProductID = int.Parse(labelProductID.Text), // 既存のID
                    ProductName = textBoxProductName.Text.Trim(),
                    Description = textBoxDescription.Text.Trim(),
                    Price = numericPrice.Value,
                    Stock = (int)numericStock.Value,
                    AlertThreshold = (int?)numericThreshold.Value,
                    IsPublished = checkBoxPublished.Checked,
                    CategoryID = (int)comboBoxCategory.SelectedValue
                };

                _updateUseCase.Execute(product);
                MessageBox.Show("商品情報を更新しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Errors), "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("更新に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
