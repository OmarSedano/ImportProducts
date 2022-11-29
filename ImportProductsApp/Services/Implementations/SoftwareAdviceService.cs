using ImportProductsApp.Mappers;
using ImportProductsApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImportProductsApp.Services.Contracts;

namespace ImportProductsApp.Services.Implementations
{
    public class SoftwareAdviceService : IProductService
    {
        private readonly ILogs _logs;
        private readonly IFileService _fileService;

        public SoftwareAdviceService(ILogs logs, IFileService fileService)
        {
            _logs = logs;
            _fileService = fileService;
        }

        public List<Product> GetProducts(string sourcePath)
        {
            _logs.Log("Reading SoftwareAdvice Products");

            var sofAdviceProducts = GetProductsSoftwareAdvice(sourcePath);
            var products = sofAdviceProducts.Select(ProductMapper.Map).ToList();

            _logs.Log($"Got SoftwareAdvice Products. Count: {products.Count}");
            _logs.Log(String.Join(", \n", products.Select(x => $"imported: Name: {x.Name}; Categories: {string.Join(",", x.Categories)}; Twitter: {x.Twitter}")));

            return products;
        }

        private List<ProductSoftwareAdvice> GetProductsSoftwareAdvice(string sourcePath)
        {
            if (!_fileService.Exists(sourcePath))
            {
                throw new ArgumentException($"Not file found in path: {sourcePath}");
            }

            SoftwareAdviceModel softwareAdviceModel = JsonConvert.DeserializeObject<SoftwareAdviceModel>(_fileService.ReadAllText(sourcePath));
            if (softwareAdviceModel == null)
            {
                throw new ArgumentNullException("softwareAdviceModel is null");
            }
            return softwareAdviceModel.Products;
        }
    }
}
