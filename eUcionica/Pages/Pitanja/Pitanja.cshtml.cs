using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DBContext;
using EntityLib;

namespace eUcionica.Pages.Pitanja
{
    public class PitanjaModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;

        [BindProperty]
        public string SearchText { get; set; }


        public PitanjaModel(DBContext.DBContextClass context)
        {
            _context = context;
        }

        public IList<Pitanje> Pitanje { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Pitanje != null)
            {
                Pitanje = await _context.Pitanje
                .Include(p => p.Nivo)
                .Include(p => p.Oblast)
                .Include(p => p.Predmet).ToListAsync();
            }
        }

        public async void OnPost()
        {
            if (SearchText == null)
            {
                Pitanje = await _context.Pitanje
                .Include(p => p.Oblast)
                .Include(p => p.Predmet).ToListAsync();
            }
            else
            {
                Pitanje = await _context.Pitanje.Where(s => EF.Functions.Like(s.Predmet.Naziv, $"%{SearchText}%") || EF.Functions.Like(s.Oblast.Naziv, $"%{SearchText}%"))
                .Include(p => p.Oblast)
                .Include(p => p.Predmet).ToListAsync();
            }
        }
    }
}
