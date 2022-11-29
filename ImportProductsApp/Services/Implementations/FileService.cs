using System.IO;
using ImportProductsApp.Services.Contracts;

namespace ImportProductsApp.Services.Implementations
{
    public class FileService : IFileService
    {
        public bool Exists(string path)
        {
            return File.Exists(path);
        }

        public string ReadAllText(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
