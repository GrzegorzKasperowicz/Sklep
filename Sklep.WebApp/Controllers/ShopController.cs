using Microsoft.AspNetCore.Mvc;
using Sklep.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList;

namespace Sklep.WebApp.Controllers
{
    public class ShopController : Controller
    {
        private readonly SklepDbContext _context;
        public ShopController(SklepDbContext context)
        {
            this._context = context;
        }

  
        public ActionResult Index(string searchString, string sortOrder, int? IdProductType, int? IdProductProducer, int? IdProductCategory, int? page, string currentFilter)

        {
            var prodTypes = new SelectList(_context.ProductType, "IdProductType", "Title");
            var prodCat = new SelectList(_context.ProductCategory, "IdProductCategory", "Title");
            var prodProd = new SelectList(_context.ProductProducer, "IdProductProducer", "Title");

            ViewBag.ProductType = prodTypes;
            ViewBag.ProductProducer = prodProd;
            ViewBag.ProductCategory = prodCat;

            var products = from s in _context.Product.Include(i => i.ProductType).Include(i => i.ProductProducer).Include(i=>i.ProductCategory)
                           orderby s.Title
                           where IdProductType == null || s.IdProductType == IdProductType
                           where IdProductProducer == null || s.IdProductProducer == IdProductProducer
                           where IdProductCategory == null || s.IdProductCategory == IdProductCategory
                           select s;


            ViewBag.PriceAscSortParm = sortOrder == "PriceAsc"? "" : "PriceAsc";
            ViewBag.PriceDscSortParm = sortOrder == "PriceDsc"? "" :"PriceDsc";
            ViewBag.ProductProducers = sortOrder == "Producer" ? "" : "Producer";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()));

            }
            switch (sortOrder)
            {
                case "PriceAsc":
                    products = products.OrderBy(s => s.Price);
                    break;
                case "PriceDsc":
                    products = products.OrderByDescending(s => s.Price);
                    break;
                case "Producer":
                    products = products.OrderBy(s => s.IdProductProducer);
                    break;
                default:
                    products = products.OrderBy(s => s.Title);
                    break;
            }
          
            return View(products);

        }

        public async Task<IActionResult> Details(int id)
        {
            ViewBag.Types = await _context.ProductType.ToListAsync();
            return View(await _context.Product.Where(t => t.IdProduct ==
           id).FirstOrDefaultAsync());
        }
        public async Task<IActionResult> Sales()
        {
            return View(await _context.Product.Where(t => t.Sale ==
           true).ToListAsync());
        }
    }

}