using System.Collections.Generic;
using System.Threading.Tasks;
using ImportProductsApp.Models;

namespace ImportProductsApp.Services.Contracts
{
    public interface IProductsRepository
    {
        Task SaveAsync(List<Product> products);
    }
}