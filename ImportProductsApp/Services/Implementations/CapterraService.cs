
using System;
using ImportProductsApp.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ImportProductsApp.Mappers;
using ImportProductsApp.Services.Contracts;
using YamlDotNet.Serialization.NamingConventions;

namespace ImportProductsApp.Services.Implementations
{
    public class CapterraService : IProductService
    {
        private readonly ILogs _logs;
        private readonly IFileService _fileService;

        public CapterraService(ILogs logs, IFileService fileService)
        {
            _logs = logs;
            _fileService = fileService;
        }

        public List<Product> GetProducts(string sourcePath)
        {
            _logs.Log("Reading Capterra Products");

            var capTerraProducts = GetProductsCapterra(sourcePath);
            var products = capTerraProducts.Select(ProductMapper.Map).ToList();

            _logs.Log($"Got Capterra Products. Count: {products.Count}");
            _logs.Log(String.Join(", \n", products.Select(x => $"imported: Name: {x.Name}; Categories: {string.Join(",", x.Categories)}; Twitter: {x.Twitter}")));

            return products;
        }

        private List<ProductCapterra> GetProductsCapterra(string sourcePath)
        {
            if (!_fileService.Exists(sourcePath))
            {
                throw new ArgumentException($"Not file found in path: {sourcePath}");
            }

            var deserializer = new YamlDotNet.Serialization.DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            var capTerraProducts = deserializer.Deserialize<List<ProductCapterra>>(_fileService.ReadAllText(sourcePath));
            return capTerraProducts;
        }
    }
}
