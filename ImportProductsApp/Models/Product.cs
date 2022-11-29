
using System.Collections.Generic;

namespace ImportProductsApp.Models
{
    public class Product
    {
        public Product()
        {
            Categories = new List<string>();
        }

        public string Name { get; set; }
        public List<string> Categories { get; set; }
        public string Twitter { get; set; }
    }
}