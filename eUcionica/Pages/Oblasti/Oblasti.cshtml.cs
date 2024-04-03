using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Oblasti
{
    public class OblastiModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public OblastiModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        public IList<Oblast> Oblast { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Oblast != null)
            {
                Oblast = await _context.Oblast
                .Include(o => o.Predmet).ToListAsync();
            }
        }
    }
}
