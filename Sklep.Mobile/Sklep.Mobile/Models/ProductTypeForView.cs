using SklepServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Mobile.Models
{
    public class ProductTypeForView
    {
        public int IdProductType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductTypeForView() { }
        public ProductTypeForView(ProductType productType)
        {
            IdProductType = productType.IdProductType;
            Title = productType.Title;
            Description = productType.Description;
        }
    }
}
