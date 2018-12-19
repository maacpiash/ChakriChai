using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cefalog.Models;
using Cefalog.Data;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cefalog.ApiControllers
{
    [Route("api/[controller]")]
    public class JsonController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JsonController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            int max = _context.Stories.Count();
            string[] stories = new string[max];

            int i = 0;
            foreach (Story story in _context.Stories)
                stories[i++] = JsonConvert.SerializeObject(story);
            return stories;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            var Story = await _context.Stories.FirstOrDefaultAsync(m => m.StoryID == id);
            if (Story == null) return NotFound();
            return Ok(JsonConvert.SerializeObject(Story));
        }
    }
}
