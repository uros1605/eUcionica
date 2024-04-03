using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityLib;

namespace eUcionica.Pages.Pitanja
{
    public class EditModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;
        private IWebHostEnvironment _environment;

        public EditModel(DBContext.DBContextClass context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Pitanje Pitanje { get; set; } = default!;

        [BindProperty]
        public IFormFile? Upload { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pitanje == null)
            {
                return NotFound();
            }

            var pitanje =  await _context.Pitanje.FirstOrDefaultAsync(m => m.PitanjeID == id);
            if (pitanje == null)
            {
                return NotFound();
            }
            Pitanje = pitanje;
           ViewData["NivoID"] = new SelectList(_context.Nivo, "NivoID", "Naziv");
           ViewData["OblastID"] = new SelectList(_context.Oblast, "OblastID", "Naziv");
           ViewData["PredmetID"] = new SelectList(_context.Predmet, "PredmetID", "Naziv");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (Upload != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\slike", Upload.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await Upload.CopyToAsync(fileStream);

                    Pitanje.Slika = Upload.FileName;

                }
            }

            _context.Attach(Pitanje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitanjeExists(Pitanje.PitanjeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Pitanja");
        }

        private bool PitanjeExists(int id)
        {
          return (_context.Pitanje?.Any(e => e.PitanjeID == id)).GetValueOrDefault();
        }
    }
}
