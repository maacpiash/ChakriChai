using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cefalog.Data;
using Cefalog.Models;

namespace Cefalog
{
    public class DetailsModel : PageModel
    {
        private readonly Cefalog.Data.ApplicationDbContext _context;

        public DetailsModel(Cefalog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Story Story { get; set; }

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
            return Page();
        }
    }
}
