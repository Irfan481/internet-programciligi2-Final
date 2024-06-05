using HaberPortali.DTO;
using HaberPortali.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HaberPortali.Controllers
{
    // localhost:5000/api/products
    [ApiController]
    [Route("api/[controller]")]
    public class HaberController : ControllerBase
    {
        
        private readonly HaberContext _context;

        public HaberController(HaberContext context)
        {
           _context = context;
        }

        // localhost:5000/api/products => GET
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _context.Products.Where(i => i.IsActive).Select(p => 
            ProductToDTO(p))
            .ToListAsync();
            return Ok(products);
        }

        // localhost:5000/api/products/1 => GET
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int? id)
        {
           if(id == null)
            {
                return NotFound();
            }

            var p = await _context
                .Products.Where(i => i.HaberId == id)
                .Select(p => ProductToDTO(p))
                .FirstOrDefaultAsync();

            if(p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Haber entity)
        {
            _context.Products.Add(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = entity.HaberId }, entity);
        }

        // localhost:5000/api/products/5 => GET
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Haber entity)
        {
            if (id != entity.HaberId)
            {
                return BadRequest();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.HaberId == id);

            if (product == null)
            {
                return NotFound();
            }

            product.HaberBaslik = entity.HaberBaslik;
            product.Tarih = entity.Tarih;
            product.IsActive = entity.IsActive;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if(id == null) 
            { 
                return NotFound();
            }

            var product = await _context.Products.FirstOrDefaultAsync(i => i.HaberId == id);

            if(product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception)
            {
                return NotFound();
            }
            return NoContent();

        }


        private static HaberDTO ProductToDTO(Haber p)
        {
            var entity = new HaberDTO();
            if(p != null)
            {
                entity.HaberId = p.HaberId;
                entity.HaberBaslik = p.HaberBaslik;
                entity.Tarih = p.Tarih;
            }
            return entity;
        }
    }


}