using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace demoForConsole231
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();

            IServiceCollection services = new ServiceCollection();
            // 使用工厂模式将配置对象注册到容器管理
            services.AddSingleton<IConfiguration>(p => config);

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();
                builder.AddDebug();
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger<Program>>();
            while(Console.ReadKey().Key != ConsoleKey.Escape)
            {
                using (logger.BeginScope("ScopeId:{scopeId}", Guid.NewGuid()))
                {
                    logger.LogDebug("Tesla");
                    logger.LogDebug(3011, "Tesla");
                    logger.LogInformation("Hello Tesla");
                    logger.LogWarning("Hi Warning");
                    logger.LogError("Has Error");
                    logger.LogError(new Exception("Hello Car"), "Has Error");
                }
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("-------------------");
            }

            Console.ReadKey();
        }
    }
}
