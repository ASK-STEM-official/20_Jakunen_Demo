using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using SO_OMS.Domain.Entities;

namespace SO_OMS.Infrastructure.Repositories
{
    public class SqlProductRepository : IProductRepository
    {
        private readonly SqlConnection _connection;

        public SqlProductRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public List<Product> Search(string productIdKeyword, string productNameKeyword, int? categoryId, bool isPublishedOnly)
        {
            var result = new List<Product>();
            var command = _connection.CreateCommand();

            var sql = @"
        SELECT ProductID, ProductName, Price, Stock, CategoryID,
               AlertThreshold, Description, IsPublished
        FROM Products
        WHERE 1 = 1";

            if (!string.IsNullOrWhiteSpace(productIdKeyword))
            {
                sql += " AND CAST(ProductID AS NVARCHAR) LIKE @idkw";
                command.Parameters.AddWithValue("@idkw", $"%{productIdKeyword}%");
            }

            if (!string.IsNullOrWhiteSpace(productNameKeyword))
            {
                sql += " AND ProductName LIKE @namekw";
                command.Parameters.AddWithValue("@namekw", $"%{productNameKeyword}%");
            }

            if (categoryId.HasValue)
            {
                sql += " AND CategoryID = @cat";
                command.Parameters.AddWithValue("@cat", categoryId.Value);
            }

            if (isPublishedOnly)
            {
                sql += " AND IsPublished = 1";
            }

            sql += " ORDER BY ProductID";
            command.CommandText = sql;

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product(
                        reader.GetInt32(reader.GetOrdinal("ProductID")),
                        reader.GetString(reader.GetOrdinal("ProductName")),
                        reader.GetDecimal(reader.GetOrdinal("Price")),
                        reader.GetInt32(reader.GetOrdinal("Stock")),
                        reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        reader.IsDBNull(reader.GetOrdinal("AlertThreshold"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("AlertThreshold")),
                        reader.IsDBNull(reader.GetOrdinal("Description"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("Description")),
                        reader.GetBoolean(reader.GetOrdinal("IsPublished"))
                    );

                    result.Add(product);
                }
            }

            return result;
        }


        public Product GetById(int productId)
        {
            var command = _connection.CreateCommand();
            command.CommandText = @"
                SELECT ProductID, ProductName, Price, Stock, CategoryID,
                       AlertThreshold, Description, IsPublished
                FROM Products
                WHERE ProductID = @id";
            command.Parameters.AddWithValue("@id", productId);

            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Product(
                        reader.GetInt32(reader.GetOrdinal("ProductID")),
                        reader.GetString(reader.GetOrdinal("ProductName")),
                        reader.GetDecimal(reader.GetOrdinal("Price")),
                        reader.GetInt32(reader.GetOrdinal("Stock")),
                        reader.GetInt32(reader.GetOrdinal("CategoryID")),
                        reader.IsDBNull(reader.GetOrdinal("AlertThreshold"))
                            ? (int?)null
                            : reader.GetInt32(reader.GetOrdinal("AlertThreshold")),
                        reader.IsDBNull(reader.GetOrdinal("Description"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("Description")),
                        reader.GetBoolean(reader.GetOrdinal("IsPublished"))
                    );
                }
            }

            return null; // 呼び出し側で null チェックが必要
        }

        public void Insert(Product product)
        {
            var command = _connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Products (ProductName, Price, Stock, CategoryID, AlertThreshold, Description, IsPublished)
                VALUES (@name, @price, @stock, @cat, @threshold, @desc, @pub)";
            command.Parameters.AddWithValue("@name", product.ProductName);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@stock", product.Stock);
            command.Parameters.AddWithValue("@cat", product.CategoryID);
            command.Parameters.AddWithValue("@threshold", (object)product.AlertThreshold ?? DBNull.Value);
            command.Parameters.AddWithValue("@desc", (object)product.Description ?? DBNull.Value);
            command.Parameters.AddWithValue("@pub", product.IsPublished);
            command.ExecuteNonQuery();
        }

        public void Update(Product product)
        {
            var command = _connection.CreateCommand();
            command.CommandText = @"
                UPDATE Products
                SET ProductName = @name,
                    Price = @price,
                    Stock = @stock,
                    CategoryID = @cat,
                    AlertThreshold = @threshold,
                    Description = @desc,
                    IsPublished = @pub
                WHERE ProductID = @id";
            command.Parameters.AddWithValue("@id", product.ProductID);
            command.Parameters.AddWithValue("@name", product.ProductName);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@stock", product.Stock);
            command.Parameters.AddWithValue("@cat", product.CategoryID);
            command.Parameters.AddWithValue("@threshold", (object)product.AlertThreshold ?? DBNull.Value);
            command.Parameters.AddWithValue("@desc", (object)product.Description ?? DBNull.Value);
            command.Parameters.AddWithValue("@pub", product.IsPublished);
            command.ExecuteNonQuery();
        }
    }
}
