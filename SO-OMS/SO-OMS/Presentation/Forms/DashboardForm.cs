using SO_OMS.Application.Interfaces;
using SO_OMS.Application.Usecases;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SO_OMS.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly LoadDashboardAlertsUseCase _loadAlertsUseCase;
        private readonly ResolveAlertUseCase _resolveAlertUseCase;
        private readonly CheckProductStockAlertUseCase _checkAlertsUseCase;
        private readonly IProductRepository _productRepository;
        private List<DashboardAlertViewModel> _alertViewModels;

        public DashboardForm(
            LoadDashboardAlertsUseCase loadAlertsUseCase,
            ResolveAlertUseCase resolveAlertUseCase,
            CheckProductStockAlertUseCase checkAlertsUseCase,
            IProductRepository productRepository
            )
        {
            InitializeComponent();
            _loadAlertsUseCase = loadAlertsUseCase;
            _resolveAlertUseCase = resolveAlertUseCase;
            _checkAlertsUseCase = checkAlertsUseCase;
            _productRepository = productRepository;
            Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            _checkAlertsUseCase.Execute();

            LoadAlerts();

            var comboCol = (DataGridViewComboBoxColumn)dataGridView1.Columns["IsResolved"];
            comboCol.DisplayMember = "Text";
            comboCol.ValueMember = "Value";
            comboCol.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
            comboCol.DataSource = new[]
            {
                new { Text = "未対応", Value = false },
                new { Text = "対応済み", Value = true }
            };

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.CurrentCellDirtyStateChanged += dataGridView1_CurrentCellDirtyStateChanged;
            dataGridView1.RowPrePaint += dataGridView1_RowPrePaint;
            dataGridView1.DataError += (s, args) => { args.ThrowException = false; };
        }

        private void LoadAlerts()
        {
            _alertViewModels = _loadAlertsUseCase.Execute();
            dataGridView1.DataSource = _alertViewModels;
        }

        private void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridView1.IsCurrentCellDirty)
            {
                dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "IsResolved")
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.DataBoundItem is DashboardAlertViewModel vm)
                {
                    _resolveAlertUseCase.Execute(vm.AlertID, vm.IsResolved);
                }
            }
        }

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            if (row.DataBoundItem is DashboardAlertViewModel vm && !vm.IsResolved)
            {
                row.DefaultCellStyle.BackColor = Color.LightPink;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var productListForm = new ProductListForm(_productRepository);
            productListForm.ShowDialog();
            _checkAlertsUseCase.Execute();
            LoadAlerts();
        }
    }
}
