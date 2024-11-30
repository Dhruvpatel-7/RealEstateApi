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
    public class InquiriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InquiriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Inquiries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inquiry>>> GetInquiry()
        {
            return await _context.Inquiry.ToListAsync();
        }

        // GET: api/Inquiries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiry(int id)
        {
            var inquiry = await _context.Inquiry.FindAsync(id);

            if (inquiry == null)
            {
                return NotFound();
            }

            return inquiry;
        }

        // PUT: api/Inquiries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInquiry(int id, Inquiry inquiry)
        {
            if (id != inquiry.Id)
            {
                return BadRequest();
            }

            _context.Entry(inquiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquiryExists(id))
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

        // POST: api/Inquiries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inquiry>> PostInquiry(Inquiry inquiry)
        {
            _context.Inquiry.Add(inquiry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInquiry", new { id = inquiry.Id }, inquiry);
        }

        // DELETE: api/Inquiries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInquiry(int id)
        {
            var inquiry = await _context.Inquiry.FindAsync(id);
            if (inquiry == null)
            {
                return NotFound();
            }

            _context.Inquiry.Remove(inquiry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InquiryExists(int id)
        {
            return _context.Inquiry.Any(e => e.Id == id);
        }
    }
}
