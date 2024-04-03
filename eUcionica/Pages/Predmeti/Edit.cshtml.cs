using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Predmeti
{
    public class EditModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public EditModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        [BindProperty]
        public Predmet Predmet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Predmet == null)
            {
                return NotFound();
            }

            var predmet =  await _context.Predmet.FirstOrDefaultAsync(m => m.PredmetID == id);
            if (predmet == null)
            {
                return NotFound();
            }
            Predmet = predmet;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            _context.Attach(Predmet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PredmetExists(Predmet.PredmetID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Predmeti");
        }

        private bool PredmetExists(int id)
        {
          return (_context.Predmet?.Any(e => e.PredmetID == id)).GetValueOrDefault();
        }
    }
}
