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
    public class ContactusController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Contactus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contactus>>> GetContactus()
        {
            return await _context.Contactus.ToListAsync();
        }

        // GET: api/Contactus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contactus>> GetContactus(int id)
        {
            var contactus = await _context.Contactus.FindAsync(id);

            if (contactus == null)
            {
                return NotFound();
            }

            return contactus;
        }

        // PUT: api/Contactus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactus(int id, Contactus contactus)
        {
            if (id != contactus.Id)
            {
                return BadRequest();
            }

            _context.Entry(contactus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactusExists(id))
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

        // POST: api/Contactus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contactus>> PostContactus(Contactus contactus)
        {
            _context.Contactus.Add(contactus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactus", new { id = contactus.Id }, contactus);
        }

        // DELETE: api/Contactus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactus(int id)
        {
            var contactus = await _context.Contactus.FindAsync(id);
            if (contactus == null)
            {
                return NotFound();
            }

            _context.Contactus.Remove(contactus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactusExists(int id)
        {
            return _context.Contactus.Any(e => e.Id == id);
        }
    }
}
