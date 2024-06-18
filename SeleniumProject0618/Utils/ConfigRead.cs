using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace SeleniumProject0618.Utils
{
    public static class ConfigReader
    {
        private static IConfigurationRoot configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetFileProvider(new PhysicalFileProvider(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            
            configuration = builder.Build();
        }

        public static string GetConfigValue(string key)
        {
            return configuration[key];
        }
    }
}
