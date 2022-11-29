
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImportProductsApp.Models;
using ImportProductsApp.Services.Contracts;

namespace ImportProductsApp.Services.Implementations
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogs _logs;

        public ProductsRepository(ILogs logs)
        {
            _logs = logs;
        }

        public async Task SaveAsync(List<Product> products)
        {
            await Task.Run(() => Console.WriteLine("Succesfully saved products in repository"));

            _logs.Log(String.Join(", \n", products.Select(x => $"saved: Name: {x.Name}; Categories: {string.Join(",", x.Categories)}; Twitter: {x.Twitter}")));
        }
    }
}
