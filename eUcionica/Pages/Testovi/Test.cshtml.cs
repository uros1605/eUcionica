using DBContext;
using EntityLib;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eUcionica.Pages.Testovi
{
    public class TestModel : PageModel
    {
        private readonly DBContextClass _context;

        public List<Pitanje> OdabranaPitanja { get; set; }

        public TestModel(DBContextClass context)
        {
            _context = context;
        }

        public int TacnihOdgovora { get; set; }
        public int UkupnoPitanja { get; set; }

        public async Task<IActionResult> OnGetAsync(int izabraniPredmet, int izabranaOblast)
        {
            var pitanja = await _context.Pitanje
                .Where(p => p.PredmetID == izabraniPredmet && p.OblastID == izabranaOblast)
                .ToListAsync();

            var random = new Random();
            OdabranaPitanja = pitanja.OrderBy(q => random.Next()).Take(5).ToList();

            return Page();
        }

        public IActionResult OnPostSubmitTest()
        {

            return RedirectToPage("./IzborTesta");

        }
    }
}
