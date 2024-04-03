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
    public class DetailsModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public DetailsModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

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
    }
}
