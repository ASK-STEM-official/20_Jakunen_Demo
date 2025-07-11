using Microsoft.Extensions.DependencyInjection;
using SO_OMS.Application.Usecases;
using SO_OMS.Infrastructure.Repositories;
using SO_OMS.Presentation.Forms;
using SO_OMS.Infrastructure.Security;

namespace SO_OMS
{
    public static class BootStrapper
    {
        public static ServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();

            // Repository
            services.AddSingleton<IAdminRepository, SqlAdminRepository>();

            // Services
            services.AddSingleton<IPasswordHasher, PBKDF2PasswordHasher>();
            services.AddSingleton<LoginUseCase>();

            // Forms
            services.AddSingleton<LoginForm>();

            return services.BuildServiceProvider();
        }
    }
}
