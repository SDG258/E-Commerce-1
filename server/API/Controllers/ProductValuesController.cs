using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductValuesController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public ProductValuesController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/ProductValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductValue>>> GetProductValues()
        {
            return await _context.ProductValues.ToListAsync();
        }

        // GET: api/ProductValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductValue>> GetProductValue(int id)
        {
            var productValue = await _context.ProductValues.FindAsync(id);

            if (productValue == null)
            {
                return NotFound();
            }

            return productValue;
        }

        // PUT: api/ProductValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductValue(int id, ProductValue productValue)
        {
            if (id != productValue.Id)
            {
                return BadRequest();
            }

            _context.Entry(productValue).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductValueExists(id))
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

        // POST: api/ProductValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductValue>> PostProductValue(ProductValue productValue)
        {
            _context.ProductValues.Add(productValue);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductValue", new { id = productValue.Id }, productValue);
        }

        // DELETE: api/ProductValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductValue(int id)
        {
            var productValue = await _context.ProductValues.FindAsync(id);
            if (productValue == null)
            {
                return NotFound();
            }

            _context.ProductValues.Remove(productValue);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductValueExists(int id)
        {
            return _context.ProductValues.Any(e => e.Id == id);
        }
    }
}
