using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Cefalog.Models;
using Cefalog.Data;
using Microsoft.EntityFrameworkCore;

namespace Cefalog.Pages.Story
{
    public class ViewXMLModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewXMLModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Story Story { get; set; }

        [BindProperty]
        public string XmlString { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Story = await _context.Stories.FirstOrDefaultAsync(m => m.StoryID == id);

            if (Story == null)
            {
                return NotFound();
            }

            XmlString = "<?xml version=\"1.0\" encoding=\"UTF - 8\"?>";
            XmlString += "<story>";

            string title = "<title>" + Story.Title + "</title>";
            string body = "<body>" + Story.Body + "</body>";
            string postedon = "<postedon>" + Story.PostedOn.ToShortDateString() + "</postedon>";

            XmlString += title + body + postedon;
            XmlString += "</story>";

            return Page();
        }
    }
}