using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.People
{
    public class CreateModel : PageModel
    {
        private readonly SampleWebApp.Models.MvcdbContext _context;

        public CreateModel(SampleWebApp.Models.MvcdbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Person Person { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Person == null || Person == null)
            {
                return Page();
            }

            _context.Person.Add(Person);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
