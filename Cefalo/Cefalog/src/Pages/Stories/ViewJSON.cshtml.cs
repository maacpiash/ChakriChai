using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Cefalog.Models;
using Cefalog.Data;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Cefalog.Pages.Story
{
    public class ViewJSONModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ViewJSONModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Models.Story Story { get; set; }

        [BindProperty]
        public string JsonString { get; set; }

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
            JsonString = JsonConvert.SerializeObject(Story);
            return Page();
        }
    }
}