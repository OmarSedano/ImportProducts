using System.Collections.Generic;

namespace ImportProductsApp.Models
{
    public class ProductSoftwareAdvice
    {
        public ProductSoftwareAdvice()
        {
            Categories = new List<string>();
        }

        public string Title { get; set; }
        public List<string> Categories { get; set; }
        public string Twitter { get; set; }
    }
}
