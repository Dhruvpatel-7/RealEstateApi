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
    public class PropertiesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PropertiesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Properties
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Properties>>> GetProperties()
        {
            return await _context.Properties.ToListAsync();
        }

        // GET: api/Properties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Properties>> GetProperties(int id)
        {
            var properties = await _context.Properties.FindAsync(id);

            if (properties == null)
            {
                return NotFound();
            }

            return properties;
        }

        // PUT: api/Properties/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProperties(int id, Properties properties)
        {
            if (id != properties.Id)
            {
                return BadRequest();
            }

            _context.Entry(properties).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertiesExists(id))
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

        // POST: api/Properties
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Properties>> PostProperties(Properties properties)
        {
            _context.Properties.Add(properties);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProperties", new { id = properties.Id }, properties);
        }

        // DELETE: api/Properties/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperties(int id)
        {
            var properties = await _context.Properties.FindAsync(id);
            if (properties == null)
            {
                return NotFound();
            }

            _context.Properties.Remove(properties);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertiesExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
