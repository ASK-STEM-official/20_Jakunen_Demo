using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Windows.Forms;

namespace SO_OMS.Infrastructure.Repositories
{
    public class SqlAlertLogRepository : IAlertLogRepository
    {
        private readonly SqlConnection _connection;

        public SqlAlertLogRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<DashboardAlertViewModel> GetAll()
        {
            var result = new List<DashboardAlertViewModel>();

            var command = _connection.CreateCommand();
            command.CommandText = @"
        SELECT a.AlertID, a.ProductID, p.ProductName, p.AlertThreshold,
               a.StockAtAlert, a.DetectedAt, a.IsResolved
        FROM AlertLogs a
        INNER JOIN Products p ON a.ProductID = p.ProductID
        ORDER BY a.DetectedAt DESC";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var alert = new DashboardAlertViewModel
                    {
                        AlertID = reader.GetInt32(reader.GetOrdinal("AlertID")),
                        ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                        ProductName = reader.GetString(reader.GetOrdinal("ProductName")),
                        AlertThreshold = reader.IsDBNull(reader.GetOrdinal("AlertThreshold"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("AlertThreshold")),
                        StockAtAlert = reader.GetInt32(reader.GetOrdinal("StockAtAlert")),
                        DetectedAt = reader.GetDateTime(reader.GetOrdinal("DetectedAt")),
                        IsResolved = reader.GetBoolean(reader.GetOrdinal("IsResolved"))
                    };
                    result.Add(alert);
                }
            }

            return result;
        }


        public void Update(AlertLog alertLog)
        {
            var command = _connection.CreateCommand();
            command.CommandText = @"
        UPDATE AlertLogs
        SET IsResolved = @IsResolved
        WHERE AlertID = @AlertID";

            command.Parameters.AddWithValue("@IsResolved", alertLog.IsResolved);
            command.Parameters.AddWithValue("@AlertID", alertLog.AlertID);

            int rows = command.ExecuteNonQuery(); // ← 必ず rows に代入する

            MessageBox.Show($"更新件数: {rows} (AlertID={alertLog.AlertID})");

        }
    }
}
