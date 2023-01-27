using SklepServiceConnection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sklep.Mobile.Models
{
    public class ProductProducerForView
    {
        public int IdProductProducer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ProductProducerForView() { }
        public ProductProducerForView(ProductProducer productProducer)
        {
            IdProductProducer = productProducer.IdProductProducer;
            Title = productProducer.Title;
            Description = productProducer.Description;
        }
    }
}