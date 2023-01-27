using Sklep.Mobile.Models;
using SklepServiceConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep.Mobile.Services
{
    public class ProductCategoryDataStore : AbstractDataStore, IDataStore<ProductCategoryForView>
    {
        public List<ProductCategoryForView> Items { get; set; }

        public ProductCategoryDataStore()
        {

            var itemsFromService = sklepServiceConnectionReference.ProductCategoryAllAsync().Result;
            Items = new List<ProductCategoryForView>();
            Items = itemsFromService.Select(category => new ProductCategoryForView(category)).ToList();
        }

        public async Task<bool> AddItemAsync(ProductCategoryForView item)
        {
            var itemToAdd = new ProductCategory
            {
                Created = DateTimeOffset.Now,
                Title = item.Title,
                Description = item.Description,
                Modified = DateTimeOffset.Now,
                IsActive = true
            };

            var items = new ProductCategoryForView(sklepServiceConnectionReference.ProductCategoryAsync(itemToAdd).Result);
            Items.Add(items);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var oldItem = Items.Where((ProductCategoryForView arg) => arg.IdProductCategory == id).FirstOrDefault();
            Items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ProductCategoryForView> GetItemAsync(int id)
        {
            return await Task.FromResult(Items.FirstOrDefault(s => s.IdProductCategory == id));
        }

        public async Task<IEnumerable<ProductCategoryForView>> GetItemsAsync(bool forceRefresh = true)
        {
            return await Task.FromResult(Items);
        }

        public async Task<bool> UpdateItemAsync(ProductCategoryForView item)
        {
            var oldItem = Items.Where((ProductCategoryForView arg) => arg.IdProductCategory == item.IdProductCategory).FirstOrDefault();
            Items.Remove(oldItem);
            Items.Add(item);

            return await Task.FromResult(true);
        }


    }
}