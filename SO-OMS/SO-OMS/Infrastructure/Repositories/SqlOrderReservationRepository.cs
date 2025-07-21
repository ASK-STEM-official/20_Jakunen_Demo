using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SO_OMS.Infrastructure.Repositories
{
    public class SqlOrderReservationRepository : IOrderReservationRepository
    {
        private readonly SqlConnection _connection;

        public SqlOrderReservationRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<OrderReservation> Search(
            string reservationId = null,
            string customerName = null,
            string productName = null,
            string status = null,
            int? categoryId = null,
            DateTime? fromDate = null,
            DateTime? toDate = null
            )
        {
            var orders = new Dictionary<string, OrderReservation>();

            using (var command = _connection.CreateCommand())
            {
                var sql = @"
                SELECT
                    o.ReservationID,
                    o.ReservationDateTime,
                    o.CustomerID,
                    c.CustomerName,
                    o.TotalAmount,
                    o.ShippingAddress,
                    o.PaymentMethod,
                    o.Status,
                    o.ImportedDateTime,
                    i.ItemID,
                    i.ProductID,
                    i.ProductName,
                    i.Quantity,
                    i.UnitPrice,
                    p.CategoryID
                FROM OrderReservations o
                INNER JOIN Customers c ON o.CustomerID = c.CustomerID
                INNER JOIN OrderReservationItems i ON o.ReservationID = i.ReservationID
                INNER JOIN Products p ON i.ProductID = p.ProductID
                WHERE 1=1
                ";

                if (!string.IsNullOrWhiteSpace(reservationId))
                {
                    sql += " AND o.ReservationID LIKE @ReservationID";
                    command.Parameters.AddWithValue("@ReservationID", $"%{reservationId}%");
                }

                if (!string.IsNullOrWhiteSpace(customerName))
                {
                    sql += " AND c.CustomerName LIKE @CustomerName";
                    command.Parameters.AddWithValue("@CustomerName", $"%{customerName}%");
                }

                if (!string.IsNullOrWhiteSpace(productName))
                {
                    sql += " AND i.ProductName LIKE @ProductName";
                    command.Parameters.AddWithValue("@ProductName", $"%{productName}%");
                }

                if (!string.IsNullOrWhiteSpace(status))
                {
                    sql += " AND o.Status = @Status";
                    command.Parameters.AddWithValue("@Status", status);
                }

                if (categoryId.HasValue)
                {
                    sql += " AND p.CategoryID = @CategoryID";
                    command.Parameters.AddWithValue("@CategoryID", categoryId.Value);
                }

                if (fromDate.HasValue)
                {
                    sql += " AND o.ReservationDateTime >= @FromDate";
                    command.Parameters.AddWithValue("@FromDate", fromDate.Value);
                }

                if (toDate.HasValue)
                {
                    sql += " AND o.ReservationDateTime <= @ToDate";
                    command.Parameters.AddWithValue("@ToDate", toDate.Value);
                }

                command.CommandText = sql;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var resId = (string)reader["ReservationID"];
                        if (!orders.TryGetValue(resId, out var order))
                        {
                            order = new OrderReservation
                            {
                                ReservationID = resId,
                                ReservationDateTime = (DateTime)reader["ReservationDateTime"],
                                CustomerID = (int)reader["CustomerID"],
                                CustomerName = (string)reader["CustomerName"], // ← JOIN結果
                                TotalAmount = reader["TotalAmount"] != DBNull.Value ? (decimal)reader["TotalAmount"] : 0,
                                ShippingAddress = reader["ShippingAddress"]?.ToString(),
                                PaymentMethod = reader["PaymentMethod"]?.ToString(),
                                Status = (string)reader["Status"],
                                ImportedDateTime = reader["ImportedDateTime"] != DBNull.Value
                                    ? (DateTime)reader["ImportedDateTime"]
                                    : DateTime.MinValue,
                                Items = new List<OrderReservationItem>()
                            };
                            orders.Add(resId, order);
                        }

                        var item = new OrderReservationItem
                        {
                            ItemID = (int)reader["ItemID"],
                            ReservationID = resId,
                            ProductID = (int)reader["ProductID"],
                            ProductName = (string)reader["ProductName"],
                            Quantity = (int)reader["Quantity"],
                            UnitPrice = (decimal)reader["UnitPrice"]
                        };

                        order.Items.Add(item);
                    }
                }
            }

            return new List<OrderReservation>(orders.Values);
        }


        public List<OrderReservation> GetAll()
        {
            return Search(); // 条件なしで全件取得
        }

        public OrderReservation FindById(string reservationId)
        {
            var list = Search(reservationId: reservationId);
            return list.Count > 0 ? list[0] : null;
        }
    }
}
