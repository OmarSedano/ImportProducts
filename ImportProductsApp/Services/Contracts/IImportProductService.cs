using System.Threading.Tasks;

namespace ImportProductsApp.Services.Contracts
{
    public interface IImportProductService
    {
        Task ImportAsync(string source, string sourcePath);
    }
}