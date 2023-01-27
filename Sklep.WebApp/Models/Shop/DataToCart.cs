using Sklep.Data.Model;

namespace Sklep.WebApp.Models.Shop
{
    public class DataToCart
    {
        public List<CartItem> CartItem { get; set; }
        public decimal Total { get; set; }
    }
}
