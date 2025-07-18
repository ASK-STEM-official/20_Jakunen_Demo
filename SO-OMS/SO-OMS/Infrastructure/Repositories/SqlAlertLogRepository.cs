using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
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

        public List<DashboardAlertViewModel> GetAll()
        {
            var result = new List<DashboardAlertViewModel>();
            using (var cmd = new SqlCommand("SELECT AlertID, ProductID, StockAtAlert, DetectedAt, IsResolved FROM AlertLogs ORDER BY DetectedAt DESC", _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DashboardAlertViewModel
                        {
                            AlertID = reader.GetInt32(0),
                            ProductID = reader.GetInt32(1),
                            StockAtAlert = reader.GetInt32(2),
                            DetectedAt = reader.GetDateTime(3),
                            IsResolved = reader.GetBoolean(4)
                        });
                    }
                }
            }
            return result;
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
            using (var cmd = new SqlCommand("SELECT TOP 1 AlertID, ProductID, StockAtAlert, DetectedAt, IsResolved FROM AlertLogs WHERE ProductID = @pid ORDER BY DetectedAt DESC", _connection))
            {
                cmd.Parameters.AddWithValue("@pid", productId);
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
    }
}
