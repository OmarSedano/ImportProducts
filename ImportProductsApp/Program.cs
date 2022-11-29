using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ImportProductsApp.Services.Implementations;
using System.Threading.Tasks;
using ImportProductsApp.Services.Contracts;
using Microsoft.Extensions.Logging;

namespace ImportProductsApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                Console.WriteLine("Initiating Product Import");
                ValidateArgs(args);

                var source = args[0];
                var sourcePath = args[1];
                
                using IHost host = CreateHostBuilder(args).Build();

                var importProductService = host.Services.GetService<IImportProductService>();
                await importProductService.ImportAsync(source, sourcePath);

                Console.WriteLine("Products Import completed!");

                await host.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. Message : {ex.Message}");
            }
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services
                        .AddLogging(c => c.ClearProviders())
                        .AddTransient<IProductsRepository, ProductsRepository>()
                        .AddTransient<ILogs, Logs>()
                        .AddTransient<IFileService, FileService>()
                        .AddTransient<IImportProductService, ImportProductService>()
                        .AddTransient<CapterraService>()
                        .AddTransient<SoftwareAdviceService>()
                        .AddTransient(ProductServiceFactory)); 
        }

        private static Func<IServiceProvider, Func<string, IProductService>> ProductServiceFactory =>
            service =>
            {
                return source =>
                {
                    var productServiceType = ProductServiceType.Get(source);
                    return (IProductService)service.GetRequiredService(productServiceType);
                };
            };

        private static void ValidateArgs(string[] args)
        {
            if (args.Length != 2)
            {
                throw new ArgumentException(
                    $"Invalid number of arguments. The arguments has to follow following format: import <Source> <sourcePath> Ex: import capterra feed-products/capterra.yaml");
            }
        }
    }
}
