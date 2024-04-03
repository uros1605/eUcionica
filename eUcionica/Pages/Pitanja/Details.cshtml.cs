using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EntityLib;

namespace eUcionica.Pages.Pitanja
{
    public class DetailsModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public DetailsModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

      public Pitanje Pitanje { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pitanje == null)
            {
                return NotFound();
            }

            var pitanje = await _context.Pitanje
                .Include(p => p.Nivo)
                .Include(p => p.Oblast)
                .Include(p => p.Predmet)
                .FirstOrDefaultAsync(m => m.PitanjeID == id);

            if (pitanje == null)
            {
                return NotFound();
            }
            else 
            {
                Pitanje = pitanje;
            }
            return Page();
        }
    }
}
