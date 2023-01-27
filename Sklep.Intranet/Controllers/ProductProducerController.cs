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
    public class ProductProducerController : Controller
    {
        private readonly SklepDbContext _context;

        public ProductProducerController(SklepDbContext context)
        {
            _context = context;
        }

        // GET: ProductProducer
        public async Task<IActionResult> Index()
        {
              return View(await _context.ProductProducer.ToListAsync());
        }

        // GET: ProductProducer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProductProducer == null)
            {
                return NotFound();
            }

            var productProducer = await _context.ProductProducer
                .FirstOrDefaultAsync(m => m.IdProductProducer == id);
            if (productProducer == null)
            {
                return NotFound();
            }

            return View(productProducer);
        }

        // GET: ProductProducer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductProducer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductProducer,Title,Description,Created,Modified,IsActicve")] ProductProducer productProducer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productProducer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productProducer);
        }

        // GET: ProductProducer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProductProducer == null)
            {
                return NotFound();
            }

            var productProducer = await _context.ProductProducer.FindAsync(id);
            if (productProducer == null)
            {
                return NotFound();
            }
            return View(productProducer);
        }

        // POST: ProductProducer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductProducer,Title,Description,Created,Modified,IsActicve")] ProductProducer productProducer)
        {
            if (id != productProducer.IdProductProducer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productProducer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductProducerExists(productProducer.IdProductProducer))
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
            return View(productProducer);
        }

        // GET: ProductProducer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProductProducer == null)
            {
                return NotFound();
            }

            var productProducer = await _context.ProductProducer
                .FirstOrDefaultAsync(m => m.IdProductProducer == id);
            if (productProducer == null)
            {
                return NotFound();
            }

            return View(productProducer);
        }

        // POST: ProductProducer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProductProducer == null)
            {
                return Problem("Entity set 'SklepDbContext.ProductProducer'  is null.");
            }
            var productProducer = await _context.ProductProducer.FindAsync(id);
            if (productProducer != null)
            {
                _context.ProductProducer.Remove(productProducer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductProducerExists(int id)
        {
          return _context.ProductProducer.Any(e => e.IdProductProducer == id);
        }
    }
}
