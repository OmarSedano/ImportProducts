namespace ImportProductsApp.Services.Contracts
{
    public interface IFileService
    {
        bool Exists(string path);
        string ReadAllText(string path);
    }
}