
using System;
using System.Threading.Tasks;
using ImportProductsApp.Services.Contracts;

namespace ImportProductsApp.Services.Implementations
{
    public class ImportProductService : IImportProductService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly Func<string, IProductService> _productServiceFactory;
        private readonly ILogs _logs;

        public ImportProductService(IProductsRepository productsRepository, Func<string, IProductService> productServiceFactory, ILogs logs)
        {
            _productsRepository = productsRepository;
            _productServiceFactory = productServiceFactory;
            _logs = logs;
        }

        public async Task ImportAsync(string source, string sourcePath)
        {
            _logs.Log("Getting Products");
            var productService = _productServiceFactory(source);
            var products = productService.GetProducts(sourcePath);

            _logs.Log("Saving Products");
            await _productsRepository.SaveAsync(products);
            _logs.Log("Saved Products");
        }
    }
}
