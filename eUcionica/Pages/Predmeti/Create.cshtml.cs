using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Predmeti
{
    public class CreateModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public CreateModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Predmet Predmet { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Predmet == null || Predmet == null)
            {
                return Page();
            }

            _context.Predmet.Add(Predmet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Predmeti");
        }
    }
}
