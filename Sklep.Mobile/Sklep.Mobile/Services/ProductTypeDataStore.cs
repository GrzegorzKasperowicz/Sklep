using Sklep.Mobile.Models;
using SklepServiceConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklep.Mobile.Services
{
    public class ProductTypeDataStore: IDataStore<ProductTypeForView>
    {
        public List<ProductTypeForView> Items { get; set; }
        private sklepServiceConnectionReference sklepServiceConnectionReference;
        public ProductTypeDataStore()
        {
            sklepServiceConnectionReference = new sklepServiceConnectionReference("https://localhost:7046", new System.Net.Http.HttpClient());
            ICollection<ProductType> itemsFromService = sklepServiceConnectionReference.ProductTypeAllAsync().Result;
            Items = new List<ProductTypeForView>();
            Items = itemsFromService.Select(category => new ProductTypeForView(category)).ToList();
        }

        public async Task<bool> AddItemAsync(ProductTypeForView item)
        {
            var itemToAdd = new ProductType
            {
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };
            var itemFromService = new ProductTypeForView(sklepServiceConnectionReference.ProductTypeAsync(itemToAdd).Result);
            Items.Add(itemFromService);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductTypeForView arg) => arg.IdProductType == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ProductTypeForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.IdProductType == id));
        }

        public async Task<IEnumerable<ProductTypeForView>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ProductTypeForView item)
        {
            var oldItem = Items.Where((ProductTypeForView arg) => arg.IdProductType == item.IdProductType).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }
    }
}
