using Sklep.Data.Model;
using Sklep.WebApp.Models.BussinesLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Sklep.WebApp.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly SklepDbContext _context;
        public PurchaseController(SklepDbContext context)
        {
            _context = context;
        }
        public IActionResult Data()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>
        Data([Bind("IdOrder, IdClient, FirstName, LastName, Street, HouseNumber,ApartmentNumber, City, Province, PostalCode, Country, PhoneNumer, Email")] Order order)
        {
            if (ModelState.IsValid)
            {
              
                order.OrderDate = DateTime.Now;
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();

                CartB cartB = new CartB(this._context, this.HttpContext);
                var cartItems = await cartB.GetCartItems();

                foreach (var item in cartItems)
                {
                    var orderItems = new OrderItem
                    {
                        IdProduct = item.IdProduct,
                        IdOrder = order.IdOrder,
                        Price = item.Product.Price,
                        Quantity = item.Quantity
                    };
                    await _context.OrderItem.AddAsync(orderItems);
                }
                order.Total = await cartB.GetTotal();
                await _context.SaveChangesAsync();
                return RedirectToAction("Summary", new { id = order.IdOrder });
            }


            return View();
        }

        public async Task<ActionResult> Summary(int id)
        {
            var order = await _context.Order.FirstOrDefaultAsync(z => z.IdOrder == id);
            if (order == null)
            {
                return View("Error");
            }
            return View(order);
        }
    }
}