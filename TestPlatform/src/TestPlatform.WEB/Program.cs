using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TestPlatform.WEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = CreateConfiguration();
            CreateHostBuilder(configuration, args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(IConfiguration config, string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureAppConfiguration(builder =>
            {
                builder.AddConfiguration(config);
            });

        private static IConfiguration CreateConfiguration()
        {
            IConfigurationBuilder configuration = new ConfigurationBuilder();

            return configuration
                .AddJsonFile("appsettings.json", false, true)
                .AddEnvironmentVariables().Build();

        }
    }
}
