using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using SO_OMS.Application.DTOs;
using SO_OMS.Presentation.ViewModels;

namespace SO_OMS.Infrastructure.Repositories
{
    public class SqlAlertLogRepository : IAlertLogRepository
    {
        private readonly SqlConnection _connection;

        public SqlAlertLogRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<DashboardAlertDto> GetDashboardAlerts()
        {
            var results = new List<DashboardAlertDto>();

            using (var cmd = new SqlCommand(@"
            SELECT 
                a.AlertID,
                a.ProductID,
                a.DetectedAt,
                a.StockAtAlert,
                a.IsResolved,
                p.AlertThreshold
            FROM AlertLogs a
            LEFT JOIN Products p ON a.ProductID = p.ProductID
            ORDER BY a.DetectedAt DESC
            ", _connection))

            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        results.Add(new DashboardAlertDto
                        {
                            AlertID = reader.GetInt32(0),
                            ProductID = reader.GetInt32(1),
                            DetectedAt = reader.GetDateTime(2),
                            StockAtAlert = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3),
                            IsResolved = reader.GetBoolean(4),
                            AlertThreshold = reader.IsDBNull(5) ? (int?)null : reader.GetInt32(5)
                        });
                    }
                }
            }

            return results;
        }


        public AlertLog GetById(int alertId)
        {
            using (var cmd = new SqlCommand("SELECT AlertID, ProductID, StockAtAlert, DetectedAt, IsResolved FROM AlertLogs WHERE AlertID = @id", _connection))
            {
                cmd.Parameters.AddWithValue("@id", alertId);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AlertLog
                        {
                            AlertID = reader.GetInt32(0),
                            ProductID = reader.GetInt32(1),
                            StockAtAlert = reader.GetInt32(2),
                            DetectedAt = reader.GetDateTime(3),
                            IsResolved = reader.GetBoolean(4)
                        };
                    }
                }
            }
            return null;
        }

        public void Update(AlertLog alert)
        {
            using (var cmd = new SqlCommand("UPDATE AlertLogs SET IsResolved = @resolved WHERE AlertID = @id", _connection))
            {
                cmd.Parameters.AddWithValue("@resolved", alert.IsResolved);
                cmd.Parameters.AddWithValue("@id", alert.AlertID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Add(AlertLog alert)
        {
            using (var cmd = new SqlCommand("INSERT INTO AlertLogs (ProductID, StockAtAlert, DetectedAt, IsResolved) VALUES (@pid, @stock, @dt, @resolved)", _connection))
            {
                cmd.Parameters.AddWithValue("@pid", alert.ProductID);
                cmd.Parameters.AddWithValue("@stock", alert.StockAtAlert);
                cmd.Parameters.AddWithValue("@dt", alert.DetectedAt);
                cmd.Parameters.AddWithValue("@resolved", alert.IsResolved);
                cmd.ExecuteNonQuery();
            }
        }

        public AlertLog GetLatestAlert(int productId)
        {
            const string sql = @"
            SELECT TOP 1 * 
            FROM AlertLogs
            WHERE ProductID = @productId
            ORDER BY DetectedAt DESC
        ";

            using (var command = new SqlCommand(sql, _connection))
            {
                command.Parameters.AddWithValue("@productId", productId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new AlertLog
                        {
                            AlertID = reader.GetInt32(reader.GetOrdinal("AlertID")),
                            ProductID = reader.GetInt32(reader.GetOrdinal("ProductID")),
                            DetectedAt = reader.GetDateTime(reader.GetOrdinal("DetectedAt")),
                            StockAtAlert = reader.IsDBNull(reader.GetOrdinal("StockAtAlert"))
                            ? 0 // NULLだったら 0 扱い
                            : reader.GetInt32(reader.GetOrdinal("StockAtAlert")),

                            IsResolved = reader.GetBoolean(reader.GetOrdinal("IsResolved"))
                        };
                    }
                }
            }

            return null;
        }
    }
}
