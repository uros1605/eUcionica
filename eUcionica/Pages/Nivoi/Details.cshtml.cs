using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Nivoi
{
    public class DetailsModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public DetailsModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

      public Nivo Nivo { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Nivo == null)
            {
                return NotFound();
            }

            var nivo = await _context.Nivo.FirstOrDefaultAsync(m => m.NivoID == id);
            if (nivo == null)
            {
                return NotFound();
            }
            else 
            {
                Nivo = nivo;
            }
            return Page();
        }
    }
}
