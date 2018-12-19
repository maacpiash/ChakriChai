using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cefalog.Data;
using Cefalog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cefalog
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly Cefalog.Data.ApplicationDbContext _context;

        public EditModel(Cefalog.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

            string currentUser = HttpContext.User.Identity.Name;

            if (currentUser != Story.AuthorID)
                return Unauthorized();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*
            Story.AuthorID = _context.Users.Where(u => u.Email == HttpContext.User.Identity.Name)
                                        .ToList().FirstOrDefault().UserName;
            */

            Story.AuthorID = HttpContext.User.Identity.Name;
            
            if (Story.PostedOn > DateTime.Now)
                ModelState.AddModelError("PostedOn", "Well hello, time traveller!");

            if (!ModelState.IsValid)
                return Page();

            _context.Attach(Story).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoryExists(Story.StoryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool StoryExists(int id)
        {
            return _context.Stories.Any(e => e.StoryID == id);
        }
    }
}
