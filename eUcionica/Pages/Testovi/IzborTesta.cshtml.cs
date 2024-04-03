using DBContext;
using EntityLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eUcionica.Pages.Testovi
{
    public class TestoviModel : PageModel
    {
        private readonly DBContextClass _context;

        public SelectList MoguciPredmeti { get; set; }
        public SelectList MoguceOblasti { get; set; }

        [BindProperty(SupportsGet = true)]
        public int izabraniPredmet { get; set; }

        [BindProperty(SupportsGet = true)]
        public int izabranaOblast { get; set; }

        public TestoviModel(DBContextClass context)
        {
            _context = context;
        }

        public void OnGet()
        {
            MoguciPredmeti = new SelectList(_context.Predmet, "PredmetID", "Naziv");
            MoguceOblasti = new SelectList(_context.Oblast, "OblastID", "Naziv");
        }

        public IActionResult OnPostSelectSubject()
        {
            if (izabraniPredmet == 0 || izabranaOblast == 0)
            {
                return Page();
            }

            return RedirectToPage("./Test", new { izabraniPredmet, izabranaOblast });
        }
    }
}