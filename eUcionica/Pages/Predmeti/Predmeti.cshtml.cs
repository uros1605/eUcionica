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
    public class PredmetiModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public PredmetiModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        public IList<Predmet> Predmet { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Predmet != null)
            {
                Predmet = await _context.Predmet.ToListAsync();
            }
        }
    }
}
