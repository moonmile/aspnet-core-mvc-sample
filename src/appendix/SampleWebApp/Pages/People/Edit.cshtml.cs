using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Models;

namespace SampleWebApp.Pages.People
{
    public class EditModel : PageModel
    {
        private readonly SampleWebApp.Models.MvcdbContext _context;

        public EditModel(SampleWebApp.Models.MvcdbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Person Person { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Person == null)
            {
                return NotFound();
            }

            var person =  await _context.Person.FirstOrDefaultAsync(m => m.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            Person = person;
           ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(Person.Id))
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

        private bool PersonExists(int id)
        {
          return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
