using System.Collections.Generic;
using ImportProductsApp.Models;

namespace ImportProductsApp.Services.Contracts
{
    public interface IProductService
    {
        public List<Product> GetProducts(string sourcePath);
    }
}