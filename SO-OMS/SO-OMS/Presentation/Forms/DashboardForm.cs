using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;

namespace SO_OMS.Presentation.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly IAlertLogRepository _alertRepository;
        private List<DashboardAlertViewModel> _alertViewModels;

        public DashboardForm(IAlertLogRepository alertRepository)
        {
            InitializeComponent();
            _alertRepository = alertRepository;
            Load += DashboardForm_Load;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            _alertViewModels = _alertRepository.GetAll();
            dataGridView1.DataSource = _alertViewModels;

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
                    var entity = new AlertLog
                    {
                        AlertID = vm.AlertID,
                        ProductID = vm.ProductID,
                        StockAtAlert = vm.StockAtAlert,
                        DetectedAt = vm.DetectedAt,
                        IsResolved = vm.IsResolved
                    };
                    _alertRepository.Update(entity);
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
            var productListForm = new ProductListForm();
            productListForm.ShowDialog();
        }
    }
}
