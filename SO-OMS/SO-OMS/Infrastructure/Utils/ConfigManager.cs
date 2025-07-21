using System.Configuration;

namespace SO_OMS.Infrastructure.Utils
{
    public static class ConfigManager
    {
        public static string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name]?.ConnectionString 
                   ?? throw new ConfigurationErrorsException($"Connection string '{name}' not found in configuration.");
        }
    }
} 