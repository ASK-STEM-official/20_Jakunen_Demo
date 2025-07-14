using SO_OMS.Application.Interfaces;
using SO_OMS.Domain.Entities;
using System;
using System.Data.SqlClient;

namespace SO_OMS.Infrastructure.Repositories
{
    public class SqlAdminRepository : IAdminRepository
    {
        private readonly SqlConnection _connection;

        public SqlAdminRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public Admin FindByUsername(string username)
        {
            var command = new SqlCommand(
                "SELECT * FROM Admins WHERE Username = @Username", _connection);
            command.Parameters.AddWithValue("@Username", username);

            SqlDataReader reader = null;
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var emailValue = reader["Email"];
                    var email = emailValue != DBNull.Value ? (string)emailValue : "";

                    return new Admin(
                        (int)reader["AdminID"],
                        (string)reader["Username"],
                        (string)reader["PasswordHash"],
                        (string)reader["FullName"],
                        email
                    );
                }
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
            }

            return null;
        }
    }
}
