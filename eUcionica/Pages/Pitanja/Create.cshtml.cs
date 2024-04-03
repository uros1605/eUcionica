using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DBContext;
using EntityLib;
using Microsoft.Extensions.Hosting;

namespace eUcionica.Pages.Pitanja
{
    public class CreateModel : PageModel
    {
        private readonly DBContext.DBContextClass _context;
        private IWebHostEnvironment _environment;

        public CreateModel(DBContext.DBContextClass context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public IActionResult OnGet()
        {
        ViewData["NivoID"] = new SelectList(_context.Nivo, "NivoID", "Naziv");
        ViewData["OblastID"] = new SelectList(_context.Oblast, "OblastID", "Naziv");
        ViewData["PredmetID"] = new SelectList(_context.Predmet, "PredmetID", "Naziv");
            return Page();
        }

        [BindProperty]
        public Pitanje Pitanje { get; set; } = default!;
        
        [BindProperty]
        public IFormFile? Upload { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (_context.Pitanje == null || Pitanje == null)
            {
                return Page();
            }

          if (Upload != null)
          {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\slike", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
              await Upload.CopyToAsync(fileStream);

              Pitanje.Slika = Upload.FileName;
            }
          }

            _context.Pitanje.Add(Pitanje);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Pitanja");
        }
    }
}
