using Microsoft.EntityFrameworkCore;
using Sklep.Data.Model;


namespace Sklep.WebApp.Models.BussinesLogic
{
    public class CartB
    {
        private readonly SklepDbContext _context;
        private string IdCartSession;
        public CartB(SklepDbContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdCartSession = GetIdCartSession(httpContext);
        }
        private string GetIdCartSession(HttpContext httpContext)
        {
            //Jeżeli w Sesji IdSesjiKoszyka jest null-em
            if (httpContext.Session.GetString("IdCartSession") == null)
            {
                //Jeżeli context.User.Identity.Name nie jest puste i nie posiada białych zanków
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    httpContext.Session.SetString("IdCartSession", httpContext.User.Identity.Name);
                }
                else
                {
                    // W przeciwnym wypadku wygeneruj przy pomocy random Guid IdSesjiKoszyka
                    Guid tempIdCartSession = Guid.NewGuid();
                    // Wyślij wygenerowane IdSesjiKoszyka jako cookie
                    httpContext.Session.SetString("IdCartSession", tempIdCartSession.ToString());
                }
            }
            return httpContext.Session.GetString("IdCartSession").ToString();
        }
        public void AddToCart(Product product)
        {
            //Najpierw sprawdzamy czy dany towar już istnieje w koszyku danego klienta
            var cartItem =
            (
            from item in _context.CartItem
            where item.IdCartSession == this.IdCartSession && item.IdProduct ==
           product.IdProduct
            select item
            ).FirstOrDefault();
            // jeżeli brak tego towaru w koszyku
            if (cartItem == null)
            {
                // Wtedy tworzymy nowy element w koszyku
                cartItem = new CartItem()
                {
                    IdCartSession = this.IdCartSession,
                    IdProduct = product.IdProduct,
                    Product = _context.Product.Find(product.IdProduct),
                    Quantity = 1,
                    Created = DateTime.Now
                };
                //i dodajemy do kolekcji lokalne
                _context.CartItem.Add(cartItem);
            }
            else
            {
                // Jeżeli dany towar istnieje już w koszyku to liczbe sztuk zwiekszamy o 1
                cartItem.Quantity++;
            }
            // Zapisujemy zmiany do bazy
            _context.SaveChanges();
        }
        public async Task<List<CartItem>> GetCartItems()
        {
            return await
            _context.CartItem.Where(e => e.IdCartSession == this.IdCartSession).Include(e
           => e.Product).ToListAsync();
        }
        public async Task<decimal> GetTotal()
        {
            var item1 =
            (
            from item in _context.CartItem
            where item.IdCartSession == this.IdCartSession
            select (decimal?)item.Quantity * item.Product.Price
            );
            return await item1.SumAsync() ?? decimal.Zero;
        }
    }
}