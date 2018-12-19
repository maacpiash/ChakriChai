using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cefalog.Data;
using Cefalog.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cefalog
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Story = new Story();
            return Page();
        }

        [BindProperty]
        public Story Story { get; set; }

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

            _context.Stories.Add(Story);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}