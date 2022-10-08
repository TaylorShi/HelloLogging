using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Debugging;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demoForAzureBlobStorage31
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .UseSerilog((hostBuilderContext, loggerConfiguration) =>
            {
                loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration);
                loggerConfiguration
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.AzureBlobStorage
                (
                    connectionString: "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://127.0.0.1:10000/devstoreaccount1;QueueEndpoint=http://127.0.0.1:10001/devstoreaccount1;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;", 
                    LogEventLevel.Information,
                    storageContainerName: "abswithserilogs",
                    storageFileName: "abswithserilog-{yyyy}-{MM}-{dd}.txt"
                );
                SelfLog.Enable(Console.Error);
            });
    }
}
