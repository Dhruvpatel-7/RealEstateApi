using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Context;
using RealEstateApi.Models;

namespace RealEstateApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GallariesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GallariesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Gallaries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gallary>>> GetGallary()
        {
            return await _context.Gallary.ToListAsync();
        }

        // GET: api/Gallaries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gallary>> GetGallary(int id)
        {
            var gallary = await _context.Gallary.FindAsync(id);

            if (gallary == null)
            {
                return NotFound();
            }

            return gallary;
        }

        // PUT: api/Gallaries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGallary(int id, Gallary gallary)
        {
            if (id != gallary.Id)
            {
                return BadRequest();
            }

            _context.Entry(gallary).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GallaryExists(id))
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

        // POST: api/Gallaries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Gallary>> PostGallary(Gallary gallary)
        {
            _context.Gallary.Add(gallary);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGallary", new { id = gallary.Id }, gallary);
        }

        // DELETE: api/Gallaries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallary(int id)
        {
            var gallary = await _context.Gallary.FindAsync(id);
            if (gallary == null)
            {
                return NotFound();
            }

            _context.Gallary.Remove(gallary);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GallaryExists(int id)
        {
            return _context.Gallary.Any(e => e.Id == id);
        }
    }
}
