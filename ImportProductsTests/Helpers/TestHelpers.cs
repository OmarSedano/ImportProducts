
using System.Reflection;

namespace ImportProductsTests.Helpers
{
    public static class TestHelpers
    {
        public static string ReadFile(string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream($"ImportProductsTests.Resources.{fileName}");
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
