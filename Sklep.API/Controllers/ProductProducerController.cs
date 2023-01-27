using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sklep.Data.Model;

namespace Sklep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductProducerController : ControllerBase
    {
        private readonly SklepDbContext _context;

        public ProductProducerController(SklepDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductProducer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductProducer>>> GetProductProducer()
        {
            return await _context.ProductProducer.ToListAsync();
        }

        // GET: api/ProductProducer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductProducer>> GetProductProducer(int id)
        {
            var productProducer = await _context.ProductProducer.FindAsync(id);

            if (productProducer == null)
            {
                return NotFound();
            }

            return productProducer;
        }

        // PUT: api/ProductProducer/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductProducer(int id, ProductProducer productProducer)
        {
            if (id != productProducer.IdProductProducer)
            {
                return BadRequest();
            }

            _context.Entry(productProducer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductProducerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProductProducer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductProducer>> PostProductProducer(ProductProducer productProducer)
        {
            _context.ProductProducer.Add(productProducer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductProducer", new { id = productProducer.IdProductProducer }, productProducer);
        }

        // DELETE: api/ProductProducer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductProducer(int id)
        {
            var productProducer = await _context.ProductProducer.FindAsync(id);
            if (productProducer == null)
            {
                return NotFound();
            }

            _context.ProductProducer.Remove(productProducer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductProducerExists(int id)
        {
            return _context.ProductProducer.Any(e => e.IdProductProducer == id);
        }
    }
}
