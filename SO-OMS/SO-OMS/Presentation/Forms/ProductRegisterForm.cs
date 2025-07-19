using SO_OMS.Application.Usecases;
using SO_OMS.Domain.Entities;
using SO_OMS.Domain.Utils;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SO_OMS.Presentation.Forms
{
    public partial class ProductRegisterForm : Form
    {
        private readonly ProductDetailViewModel _viewModel;
        private readonly RegisterProductUseCase _registerUseCase;

        public ProductRegisterForm(RegisterProductUseCase registerUseCase)
        {
            InitializeComponent();
            _viewModel = new ProductDetailViewModel(new ProductViewModel(), isEditMode: false);
            _registerUseCase = registerUseCase;

            Load += ProductRegisterForm_Load;
            buttonRegister.Click += buttonRegister_Click;
            buttonCancel.Click += (s, e) => Close();
        }

        private void ProductRegisterForm_Load(object sender, EventArgs e)
        {
            Text = _viewModel.Title;

            comboBoxCategory.DataSource = CategoryResolver.GetAll().ToList();
            comboBoxCategory.DisplayMember = "Value";
            comboBoxCategory.ValueMember = "Key";
            comboBoxCategory.SelectedValue = 1;

            numericPrice.Value = 1;
            numericStock.Value = 0;
            numericThreshold.Value = 0;
            checkBoxPublished.Checked = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
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

            var product = new Product
            {
                ProductName = _viewModel.Product.ProductName,
                Description = _viewModel.Product.Description,
                Price = _viewModel.Product.Price,
                Stock = _viewModel.Product.Stock,
                IsPublished = _viewModel.Product.IsPublished,
                AlertThreshold = _viewModel.Product.AlertThreshold,
                CategoryID = CategoryResolver.GetId(_viewModel.Product.Category)
            };

            try
            {
                _registerUseCase.Execute(product);
                MessageBox.Show("商品を登録しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (numericStock.Value < 0 || numericThreshold.Value < 0)
            {
                MessageBox.Show("在庫数およびしきい値は0以上を入力してください。", "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
    }
}
