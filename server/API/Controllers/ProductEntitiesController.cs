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
    public class ProductEntitiesController : ControllerBase
    {
        private readonly ECommerceContext _context;

        public ProductEntitiesController(ECommerceContext context)
        {
            _context = context;
        }

        // GET: api/ProductEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductEntity>>> GetProductEntities()
        {
            return await _context.ProductEntities.ToListAsync();
        }

        // GET: api/ProductEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductEntity(int id)
        {
            var productEntity = await _context.ProductEntities.FindAsync(id);

            if (productEntity == null)
            {
                return NotFound();
            }

            return productEntity;
        }

        // PUT: api/ProductEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductEntity(int id, ProductEntity productEntity)
        {
            if (id != productEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(productEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductEntityExists(id))
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

        // POST: api/ProductEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductEntity>> PostProductEntity(ProductEntity productEntity)
        {
            _context.ProductEntities.Add(productEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductEntity", new { id = productEntity.Id }, productEntity);
        }

        // DELETE: api/ProductEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductEntity(int id)
        {
            var productEntity = await _context.ProductEntities.FindAsync(id);
            if (productEntity == null)
            {
                return NotFound();
            }

            _context.ProductEntities.Remove(productEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductEntityExists(int id)
        {
            return _context.ProductEntities.Any(e => e.Id == id);
        }
    }
}
