using SO_OMS.Application.Usecases.Products;
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
            try
            {
                var product = new Product
                {
                    ProductName = textBoxProductName.Text.Trim(),
                    Description = textBoxDescription.Text.Trim(),
                    Price = numericPrice.Value,
                    Stock = (int)numericStock.Value,
                    AlertThreshold = (int?)numericThreshold.Value,
                    IsPublished = checkBoxPublished.Checked,
                    CategoryID = (int)comboBoxCategory.SelectedValue
                };

                _registerUseCase.Execute(product);
                MessageBox.Show("商品を登録しました。", "完了", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show(string.Join("\n", ex.Errors), "入力エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("登録に失敗しました：" + ex.Message, "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
