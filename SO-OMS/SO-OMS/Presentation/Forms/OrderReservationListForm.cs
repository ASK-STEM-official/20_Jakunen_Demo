using SO_OMS.Domain.Utils;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SO_OMS.Presentation.Forms
{
    public partial class OrderReservationListForm : Form
    {
        private readonly OrderReservationListViewModel _viewModel;
        private readonly IServiceProvider _provider;

        public OrderReservationListForm(
            OrderReservationListViewModel viewModel,
            IServiceProvider provider)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _provider = provider;

            Load += OrderReservationListForm_Load;
            buttonSearch.Click += buttonSearch_Click;
        }

        private void OrderReservationListForm_Load(object sender, EventArgs e)
        {
            comboBoxProductCategory.DataSource = CategoryResolver.GetAll()
                .Prepend(new KeyValuePair<int, string>(0, "すべて"))
                .ToList();
            comboBoxProductCategory.DisplayMember = "Value";
            comboBoxProductCategory.ValueMember = "Key";
            comboBoxProductCategory.SelectedIndex = 0;

            comboBoxStatus.DataSource = OrderStatusResolver.GetAll().Prepend("すべて").ToList();
            comboBoxStatus.SelectedIndex = 0;

            dateTimePickerFrom.Value = DateTime.Today.AddMonths(-1);
            dateTimePickerTo.Value = DateTime.Today;

            LoadOrders();
        }

        private void LoadOrders()
        {
            _viewModel.SearchReservationID = textBoxReservationID.Text.Trim();
            _viewModel.SearchCustomerName = textBoxCustomerName.Text.Trim();
            _viewModel.SearchProductName = textBoxProductName.Text.Trim();
            object selected = comboBoxProductCategory.SelectedValue;
            int? categoryId = (selected is int) ? (int)selected : (int?)null;
            _viewModel.SearchCategoryID = categoryId == 0 ? null : categoryId;

            _viewModel.SearchStatus = comboBoxStatus.SelectedItem?.ToString() == "すべて" ? null : comboBoxStatus.SelectedItem?.ToString();
            _viewModel.SearchFromDate = dateTimePickerFrom.Value.Date;
            _viewModel.SearchToDate = dateTimePickerTo.Value.Date;

            _viewModel.LoadOrders();

            dataGridViewOrders.AutoGenerateColumns = true;
            dataGridViewOrders.DataSource = _viewModel.Orders;
            labelCount.Text = $"{_viewModel.ResultCount} 件";
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }
    }
}
