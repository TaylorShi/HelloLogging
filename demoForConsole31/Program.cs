using demoForConsole31.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace demoForConsole31
{
    class Program
    {
        static void Main(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var config = builder.Build();

            IServiceCollection services = new ServiceCollection();
            // 使用工厂模式将配置对象注册到容器管理
            services.AddSingleton<IConfiguration>(p => config);
            services.AddTransient<OrderService>();

            services.AddLogging(builder =>
            {
                builder.AddConfiguration(config.GetSection("Logging"));
                builder.AddConsole();
                builder.AddDebug();
            });

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var orderService = serviceProvider.GetService<OrderService>();
            orderService.Show();

            //ILoggerFactory loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            //ILogger logger = loggerFactory.CreateLogger("carLogger");
            //logger.LogDebug("Tesla");
            //logger.LogDebug(3011, "Tesla");
            //logger.LogInformation("Hello Tesla");
            //logger.LogWarning("Hi Warning");
            //logger.LogError("Has Error");
            //logger.LogError(new Exception("Hello Car"), "Has Error");

            Console.ReadKey();
        }
    }
}
