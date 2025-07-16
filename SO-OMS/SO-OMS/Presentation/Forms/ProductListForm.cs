using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SO_OMS.Presentation.Forms
{
    public partial class ProductListForm : Form
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductListViewModel viewModel = new ProductListViewModel();


        public ProductListForm(IProductRepository productRepository)
        {
            InitializeComponent();
            _productRepository = productRepository;
            Load += ProductListForm_Load;
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            comboBoxCategory.Items.Clear();
            comboBoxCategory.Items.Add(new ComboBoxItem("すべて", null));
            comboBoxCategory.Items.Add(new ComboBoxItem("食品", 1));
            comboBoxCategory.Items.Add(new ComboBoxItem("雑貨", 2));
            comboBoxCategory.Items.Add(new ComboBoxItem("その他", 3));
            comboBoxCategory.SelectedIndex = 0;

            checkBoxIsPublished.Checked = true;
            LoadProducts();
        }

        private void LoadProducts()
        {
            string keywordId = textBoxProductID.Text.Trim();
            string keywordName = textBoxProductName.Text.Trim();
            int? categoryId = (comboBoxCategory.SelectedItem as ComboBoxItem)?.Value;
            bool isPublishedOnly = checkBoxIsPublished.Checked;

            var products = _productRepository.Search(keywordId, keywordName, categoryId, isPublishedOnly);

            viewModel.Products = products.Select(p => new ProductViewModel
            {
                ProductID = p.ProductID,
                ProductName = p.ProductName,
                Price = p.Price,
                Stock = p.Stock,
                Category = GetCategoryName(p.CategoryID),
                Description = p.Description,
                IsPublished = p.IsPublished
            }).ToList();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = viewModel.Products;

            labelCount.Text = $"{viewModel.ResultCount} 件";
        }

        private string GetCategoryName(int categoryId)
        {
            switch (categoryId)
            {
                case 1: return "食品";
                case 2: return "雑貨";
                default: return "その他";
            }
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
    }
}
