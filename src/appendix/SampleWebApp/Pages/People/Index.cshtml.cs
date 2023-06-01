using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.People
{
    public class IndexModel : PageModel
    {
        private readonly SampleWebApp.Models.MvcdbContext _context;

        public IndexModel(SampleWebApp.Models.MvcdbContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Person != null)
            {
                Address.Initialize(_context);

                Person = await _context.Person
                .Include(p => p.Address).ToListAsync();
            }
        }
    }
}
