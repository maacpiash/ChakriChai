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
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public PaginatedList<Story> Stories { get;set; }
        public string CurrentFilter { get; set; }

        public Dictionary<string, string> AuthorNames { get; set; }

        public async Task OnGetAsync(string currentFilter, string searchString, int? pageIndex)
        {
            InitAuthorNames(); // So that the user views the "Name"s of the authors, and not their email addresses

            if (searchString != null) pageIndex = 1;            
            else searchString = currentFilter;            

            CurrentFilter = searchString;

            IQueryable<Story> IqStories = from s in _context.Stories select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                IqStories = IqStories.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper())
                                       || s.Body.ToUpper().Contains(searchString.ToUpper()));
            }
            IqStories = IqStories.OrderByDescending(story => story.PostedOn);

            int pageSize = 4;

            Stories = await PaginatedList<Story>.CreateAsync(IqStories.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        private void InitAuthorNames()
        {
            AuthorNames = new Dictionary<string, string>();
            foreach (var blogger in _context.Users)
                AuthorNames.Add(blogger.UserName, blogger.Name);
        }
    }
}
