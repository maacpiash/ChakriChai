using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cefalog.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cefalog.ApiControllers
{
    [Route("api/[controller]")]
    public class XmlController : Controller
    {
        private readonly ApplicationDbContext _context;

        public XmlController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public string Get()
        {
            string response = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><Stories>";
            string title, body, postedon;
            foreach (var story in _context.Stories)
            {
                title = "<title>" + story.Title + "</title>";
                body = "<body>" + story.Body + "</body>";
                postedon = "<postedon>" + story.PostedOn.ToShortDateString() + "</postedon>";
                response += title + body + postedon;
            }
            response += "</stories>";
            return response;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> GetAsync(int id)
        {
            var story = await _context.Stories.FirstOrDefaultAsync(m => m.StoryID == id);
            string response = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?><Stories>";
            
            string title = "<title>" + story.Title + "</title>";
            string body = "<body>" + story.Body + "</body>";
            string postedon = "<postedon>" + story.PostedOn.ToShortDateString() + "</postedon>";

            response += title + body + postedon;
            response += "</stories>";
            return response;
        }
    }
}
