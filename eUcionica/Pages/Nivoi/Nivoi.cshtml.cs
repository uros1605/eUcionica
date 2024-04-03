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
    public class NivoiModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        public NivoiModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        public IList<Nivo> Nivo { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Nivo != null)
            {
                Nivo = await _context.Nivo.ToListAsync();
            }
        }
    }
}
