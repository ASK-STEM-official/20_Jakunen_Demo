using SO_OMS.Application.Interfaces;
using SO_OMS.Application.Usecases;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SO_OMS.Domain.Utils;
using Microsoft.Extensions.DependencyInjection;


namespace SO_OMS.Presentation.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly IServiceProvider _provider;
        private readonly ProductListViewModel _viewModel;
        private readonly UpdateProductUseCase _updateUseCase;

        public ProductListForm(
            IProductRepository productRepository, 
            ProductListViewModel viewModel, 
            UpdateProductUseCase updateUseCase, 
            IServiceProvider provider
            )
        {
            InitializeComponent();
            _productRepository = productRepository;
            _viewModel = viewModel;
            _updateUseCase = updateUseCase;
            _provider = provider;
            Load += ProductListForm_Load;
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.DataSource = CategoryResolver.GetAll()
                .Prepend(new KeyValuePair<int, string>(0, "すべて"))
                .ToList();
            comboBoxCategory.DisplayMember = "Value";
            comboBoxCategory.ValueMember = "Key";

            checkBoxIsPublished.Checked = true;
            LoadProducts();
        }

        private void LoadProducts()
        {
            _viewModel.SearchProductId = textBoxProductID.Text.Trim();
            _viewModel.SearchProductName = textBoxProductName.Text.Trim();
            _viewModel.SearchCategory = (comboBoxCategory.SelectedValue?.ToString() == "0") ? null : comboBoxCategory.SelectedValue?.ToString();
            _viewModel.ShowOnlyPublished = checkBoxIsPublished.Checked;

            _viewModel.LoadProducts();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _viewModel.Products;

            labelCount.Text = $"{_viewModel.ResultCount} 件";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private class ComboBoxItem
        {
            public string Display { get; }
            public int? Value { get; }

            public ComboBoxItem(string display, int? value)
            {
                Display = display;
                Value = value;
            }

            public override string ToString() => Display;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "ProductDetail")
            {
                if (dataGridView1.Rows[e.RowIndex].DataBoundItem is ProductViewModel vm)
                {
                    var detailViewModel = new ProductDetailViewModel(vm, isEditMode: true);

                    var detailForm = ActivatorUtilities.CreateInstance<ProductDetailForm>(
                        _provider,
                        detailViewModel,
                        _updateUseCase
                    );

                    detailForm.ShowDialog();
                    LoadProducts();
                }
            }
        }



        private void RegisterButton_Click(object sender, EventArgs e)
        {
            var registerForm = ActivatorUtilities.CreateInstance<ProductRegisterForm>(
                _provider
            );

            registerForm.ShowDialog();
            LoadProducts();
        }


    }
}
