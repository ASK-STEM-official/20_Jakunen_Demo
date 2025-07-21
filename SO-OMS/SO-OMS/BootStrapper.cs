using Microsoft.Extensions.DependencyInjection;
using SO_OMS.Application.Interfaces;
using SO_OMS.Application.Usecases.Alert;
using SO_OMS.Application.Usecases.Auth;
using SO_OMS.Application.Usecases.Order;
using SO_OMS.Application.Usecases.Products;
using SO_OMS.Domain.Services;
using SO_OMS.Infrastructure.Repositories;
using SO_OMS.Infrastructure.Security;
using SO_OMS.Infrastructure.Utils;
using SO_OMS.Presentation.Forms;
using SO_OMS.Presentation.ViewModels;
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

            // DomainServices
            services.AddSingleton<StockAlertDomainService>();
            services.AddSingleton<ProductValidationService>();
            // Repository  
            services.AddSingleton<IAdminRepository, SqlAdminRepository>();
            services.AddSingleton<IAlertLogRepository, SqlAlertLogRepository>();
            services.AddSingleton<IProductRepository, SqlProductRepository>();
            services.AddSingleton<IOrderReservationRepository, SqlOrderReservationRepository>();

            // Usecase  
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<LoadDashboardAlertsUseCase>();
            services.AddTransient<ResolveAlertUseCase>();
            services.AddTransient<CheckProductStockAlertUseCase>();
            services.AddSingleton<LoginUseCase>();
            services.AddSingleton<ListProductsUseCase>();
            services.AddSingleton<GetProductDetailUseCase>();
            services.AddSingleton<RegisterProductUseCase>();
            services.AddSingleton<UpdateProductUseCase>();
            services.AddSingleton<ListOrdersUseCase>();
            // ViewModels
            services.AddSingleton<ProductListViewModel>();
            services.AddSingleton<ProductDetailViewModel>();
            services.AddSingleton<OrderReservationListViewModel>();

            // Forms
            services.AddSingleton<LoginForm>();
            services.AddSingleton<DashboardForm>();
            services.AddSingleton<ProductListForm>();
            services.AddTransient<ProductDetailForm>();
            services.AddTransient<ProductRegisterForm>();
            services.AddTransient<OrderReservationListForm>();

            return services.BuildServiceProvider();
        }
    }
}
