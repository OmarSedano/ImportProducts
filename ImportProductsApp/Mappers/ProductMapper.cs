using System;
using System.Collections.Generic;
using System.Linq;
using ImportProductsApp.Models;

namespace ImportProductsApp.Mappers
{
    public static class ProductMapper
    {
        public static Product Map(ProductCapterra productCapterra)
        {
            if (productCapterra == null)
            {
                throw new ArgumentNullException("ProductCapterra can not be null");
            }
            return new Product()
            {
                Name = productCapterra.Name,
                Categories = productCapterra.Tags?.Split(',').ToList() ?? new List<string>(),
                Twitter = $"@{productCapterra.Twitter}"
            };
        }

        public static Product Map(ProductSoftwareAdvice productSoftAdvice)
        {
            if (productSoftAdvice == null)
            {
                throw new ArgumentNullException("ProductSoftAdvice can not be null");
            }
            return new Product()
            {
                Name = productSoftAdvice.Title,
                Categories = productSoftAdvice.Categories ?? new List<string>(),
                Twitter = productSoftAdvice.Twitter
            };
        }
    }
}
