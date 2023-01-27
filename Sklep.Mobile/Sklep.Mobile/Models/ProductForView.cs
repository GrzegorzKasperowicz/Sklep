using SklepServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Mobile.Models
{
    public class ProductForView
    {
        public int IdProduct { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Picture { get; set; }
        public string Description { get; set; }

        public bool Sale { get; set; }

        public int IdProductProducer { get; set; }
        public string TitleProductProducer { get; set; }

        public int IdProductType { get; set; }
        public string TitleProductType { get; set; }
        public int IdProductCategory { get; set; }
        public string TitleProductCategory { get; set; }

        public ProductForView() { }
        public ProductForView(Product product)
        {
            IdProduct = product.IdProduct;
            Code = product.Code;
            Title= product.Title;
            Price = (decimal)product.Price;
            Picture = product.Picture;
            Description = product.Description;
            Sale = product.Sale;
            IdProductCategory = product.IdProductCategory;
            TitleProductCategory = product.ProductCategory.Title;
            IdProductType = product.IdProductType;
            TitleProductType= product.ProductType.Title;    
            IdProductProducer= product.IdProductProducer;
            TitleProductProducer = product.ProductProducer.Title;
        }
    }
}