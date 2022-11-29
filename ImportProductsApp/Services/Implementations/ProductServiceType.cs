using System;

namespace ImportProductsApp.Services.Implementations
{
    public static class ProductServiceType
    {
        public static Type Get(string source)
        {
            if (source.Equals("capterra", StringComparison.InvariantCultureIgnoreCase))
            {
                return typeof(CapterraService);
            }

            if (source.Equals("softwareadvice", StringComparison.InvariantCultureIgnoreCase))
            {
                return typeof(SoftwareAdviceService);
            }

            throw new ArgumentException($"Not type implementation found for source '{source};");
        }
    }
}
