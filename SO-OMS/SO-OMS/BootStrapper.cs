using Microsoft.Extensions.DependencyInjection;
using SO_OMS.Application.Interfaces;
using SO_OMS.Application.UseCases;
using SO_OMS.Infrastructure.Repositories;
using SO_OMS.Infrastructure.Security;
using SO_OMS.Infrastructure.Utils;
using SO_OMS.Presentation.Forms;
using System.Data.SqlClient;

namespace SO_OMS
{
    public static class BootStrapper
    {
        public static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            // DB接続  
            services.AddSingleton<SqlConnection>(provider =>
            {
                var connectionString = ConfigManager.GetConnectionString("OliveShopDB");
                var connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            // Repository  
            services.AddSingleton<IAdminRepository, SqlAdminRepository>();
            services.AddSingleton<IAlertLogRepository, SqlAlertLogRepository>();
            services.AddSingleton<IProductRepository, SqlProductRepository>();
            // Services  
            services.AddSingleton<IPasswordHasher, PasswordHasher>();

            // UseCase
            services.AddSingleton<LoginUseCase>();

            // Forms
            services.AddSingleton<LoginForm>();
            services.AddSingleton<DashboardForm>();
            services.AddSingleton<ProductListForm>();

            return services.BuildServiceProvider();
        }
    }
}
