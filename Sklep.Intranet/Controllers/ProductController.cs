using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Model;

namespace Sklep.Intranet.Controllers
{
    public class ProductController : Controller
    {
        private readonly SklepDbContext _context;

        public ProductController(SklepDbContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var sklepDbContext = _context.Product.Include(p => p.ProductProducer).Include(p => p.ProductType).Include(p=>p.ProductCategory);
            return View(await sklepDbContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductProducer)
                .Include(p => p.ProductType)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["IdProductProducer"] = new SelectList(_context.ProductProducer, "IdProductProducer", "Title");
            ViewData["IdProductType"] = new SelectList(_context.ProductType, "IdProductType", "Title");
            ViewData["IdProductCategory"] = new SelectList(_context.ProductCategory, "IdProductCategory", "Title");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProduct,Code,Title,Price,Picture,Description,Sale,Created,Modified,IsActive,IdProductType,IdProductCategory,IdProductProducer")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProductProducer"] = new SelectList(_context.ProductProducer, "IdProductProducer", "Title", product.IdProductProducer);
            ViewData["IdProductType"] = new SelectList(_context.ProductType, "IdProductType", "Title", product.IdProductType);
            ViewData["IdProductCategory"] = new SelectList(_context.ProductCategory, "IdProductCategory", "Title", product.IdProductCategory);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["IdProductProducer"] = new SelectList(_context.ProductProducer, "IdProductProducer", "Title", product.IdProductProducer);
            ViewData["IdProductType"] = new SelectList(_context.ProductType, "IdProductType", "Title", product.IdProductType);
            ViewData["IdProductCategory"] = new SelectList(_context.ProductCategory, "IdProductCategory", "Title", product.IdProductCategory);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProduct,Code,Title,Price,Picture,Description,Sale,Created,Modified,IsActive,IdProductType,IdProductCategory,IdProductProducer")] Product product)
        {
            if (id != product.IdProduct)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.IdProduct))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdProductProducer"] = new SelectList(_context.ProductProducer, "IdProductProducer", "Title", product.IdProductProducer);
            ViewData["IdProductType"] = new SelectList(_context.ProductType, "IdProductType", "Title", product.IdProductType);
            ViewData["IdProductCategory"] = new SelectList(_context.ProductCategory, "IdProductCategory", "Title", product.IdProductCategory);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.ProductProducer)
                .Include(p => p.ProductType)
                .Include(p => p.ProductCategory)
                .FirstOrDefaultAsync(m => m.IdProduct == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'SklepDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return _context.Product.Any(e => e.IdProduct == id);
        }
    }
}
