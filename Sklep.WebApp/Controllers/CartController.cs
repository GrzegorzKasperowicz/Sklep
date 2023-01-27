using Microsoft.AspNetCore.Mvc;
using Sklep.Data.Model;
using Sklep.WebApp.Models.BussinesLogic;
using Sklep.WebApp.Models.Shop;

namespace Sklep.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly SklepDbContext _context;
        public CartController(SklepDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var dataToCart = new DataToCart
            {
                CartItem = await cart.GetCartItems(),
                Total = await cart.GetTotal()
            };
            return View(dataToCart);
        }
        public async Task<ActionResult> AddToCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.AddToCart(await _context.Product.FindAsync(id));
            return RedirectToAction("Index");
        }
    }

}

