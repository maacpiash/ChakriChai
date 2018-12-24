using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using A4A.Data;

namespace A4A.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessAgentsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusinessAgentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/BusinessAgents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessAgents>>> GetBusinessAgents()
        {
            return await _context.BusinessAgents.ToListAsync();
        }

        // GET: api/BusinessAgents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessAgents>> GetBusinessAgents(long id)
        {
            var businessAgents = await _context.BusinessAgents.FindAsync(id);

            if (businessAgents == null)
            {
                return NotFound();
            }

            return businessAgents;
        }

        // PUT: api/BusinessAgents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinessAgents(long id, BusinessAgents businessAgents)
        {
            if (id != businessAgents.BusinessId)
            {
                return BadRequest();
            }

            _context.Entry(businessAgents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessAgentsExists(id))
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

        // POST: api/BusinessAgents
        [HttpPost]
        public async Task<ActionResult<BusinessAgents>> PostBusinessAgents(BusinessAgents businessAgents)
        {
            _context.BusinessAgents.Add(businessAgents);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessAgents", new { id = businessAgents.BusinessId }, businessAgents);
        }

        // DELETE: api/BusinessAgents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessAgents>> DeleteBusinessAgents(long id)
        {
            var businessAgents = await _context.BusinessAgents.FindAsync(id);
            if (businessAgents == null)
            {
                return NotFound();
            }

            _context.BusinessAgents.Remove(businessAgents);
            await _context.SaveChangesAsync();

            return businessAgents;
        }

        private bool BusinessAgentsExists(long id)
        {
            return _context.BusinessAgents.Any(e => e.BusinessId == id);
        }
    }
}
