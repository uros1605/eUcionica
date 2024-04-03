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

namespace eUcionica.Pages.Nivoi
{
    public class EditModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public EditModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        [BindProperty]
        public Nivo Nivo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nivo == null)
            {
                return NotFound();
            }

            var nivo =  await _context.Nivo.FirstOrDefaultAsync(m => m.NivoID == id);
            if (nivo == null)
            {
                return NotFound();
            }
            Nivo = nivo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Attach(Nivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivoExists(Nivo.NivoID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Nivoi");
        }

        private bool NivoExists(int id)
        {
          return (_context.Nivo?.Any(e => e.NivoID == id)).GetValueOrDefault();
        }
    }
}
