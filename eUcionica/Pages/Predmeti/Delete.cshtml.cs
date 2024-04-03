using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Predmeti
{
    public class DeleteModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public DeleteModel(DBContext.DBContextClass context)
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

            var predmet = await _context.Predmet.FirstOrDefaultAsync(m => m.PredmetID == id);

            if (predmet == null)
            {
                return NotFound();
            }
            else 
            {
                Predmet = predmet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Predmet == null)
            {
                return NotFound();
            }
            var predmet = await _context.Predmet.FindAsync(id);

            if (predmet != null)
            {
                Predmet = predmet;
                _context.Predmet.Remove(Predmet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Predmeti");
        }
    }
}
