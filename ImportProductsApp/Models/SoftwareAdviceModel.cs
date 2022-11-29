
using System.Collections.Generic;

namespace ImportProductsApp.Models
{
    public class SoftwareAdviceModel
    {
        public SoftwareAdviceModel()
        {
            Products = new List<ProductSoftwareAdvice>();
        }

        public List<ProductSoftwareAdvice> Products { get; set; }
    }
}
