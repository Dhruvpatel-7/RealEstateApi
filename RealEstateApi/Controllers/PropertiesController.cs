using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstateApi.Context;
using RealEstateApi.Models;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

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

        // POST: api/Properties
        [HttpPost]
        public async Task<ActionResult<Properties>> PostProperty([FromForm] Properties property, [FromForm] IFormFile[] images)
        {
            try
            {
                // Check if User_Id is received correctly
                Console.WriteLine($"Received User Id: {property.User_Id}");

                // Save property details in the database
                _context.Properties.Add(property);
                await _context.SaveChangesAsync();

                // Handle image uploads
                if (images != null && images.Length > 0)
                {
                    foreach (var file in images)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            // Add image data to Gallary table
                            var gallary = new Gallary
                            {
                                PropertyId = property.Id,
                                Img_name = fileName,
                                Path = filePath
                            };
                            _context.Gallary.Add(gallary);
                        }
                    }
                    await _context.SaveChangesAsync();
                }

                return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
            }
            catch (Exception ex)
            {
                // Log the error for troubleshooting
                Console.WriteLine($"Error occurred: {ex.Message}");
                return StatusCode(500, "Internal server error occurred.");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Properties>>> GetProperties()
        {
            // Include the Gallery images with each property
            var properties = await _context.Properties
                .Include(p => p.Gallary) // Change to p.Gallary if that's the correct property name
                .ToListAsync();

            // Check if any properties are found
            if (properties == null || properties.Count == 0)
            {
                return NotFound("No properties found.");
            }

            return Ok(properties);
        }
        // GET: api/Properties/{id}
        [HttpGet("prop/{id}")]
        public async Task<ActionResult<Properties>> GetPropertyById(int id)
        {
            var property = await _context.Properties
                .Include(p => p.Gallary)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (property == null)
            {
                return NotFound("Property not found.");
            }

            return Ok(property);
        }

        // GET: api/Properties/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Properties>> GetProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return property;
        }

        // GET: api/Properties/{id}/images
        [HttpGet("{id}/images")]
        public async Task<ActionResult<IEnumerable<Gallary>>> GetPropertyImages(int id)
        {
            var images = await _context.Gallary.Where(g => g.PropertyId == id).ToListAsync();
            if (images == null || images.Count == 0)
            {
                return NotFound("No images found for this property.");
            }

            return images;
        }

        // PUT: api/Properties/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, [FromForm] Properties property, [FromForm] IFormFile[] images)
        {
            if (id != property.Id)
            {
                return BadRequest("Property ID mismatch.");
            }

            // Update property details
            _context.Entry(property).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                // Handle image updates
                if (images != null && images.Length > 0)
                {
                    // Remove old images
                    var existingImages = await _context.Gallary.Where(g => g.PropertyId == id).ToListAsync();
                    _context.Gallary.RemoveRange(existingImages);
                    await _context.SaveChangesAsync();

                    // Add new images
                    foreach (var file in images)
                    {
                        if (file.Length > 0)
                        {
                            var fileName = Path.GetFileName(file.FileName);
                            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await file.CopyToAsync(stream);
                            }

                            var gallary = new Gallary
                            {
                                PropertyId = property.Id,
                                Img_name = fileName,
                                Path = filePath
                            };

                            _context.Gallary.Add(gallary);
                        }
                    }
                    await _context.SaveChangesAsync();
                }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PropertyExists(id))
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

        // DELETE: api/Properties/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProperty(int id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property == null)
            {
                return NotFound();
            }

            // Delete all images associated with the property
            var images = await _context.Gallary.Where(g => g.PropertyId == id).ToListAsync();
            _context.Gallary.RemoveRange(images);
            await _context.SaveChangesAsync();

            // Delete property
            _context.Properties.Remove(property);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PropertyExists(int id)
        {
            return _context.Properties.Any(e => e.Id == id);
        }
    }
}
