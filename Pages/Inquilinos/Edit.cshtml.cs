using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Inquilinos
{
    public class EditModel : PageModel
    {
        private readonly AlquilerContext _context;

        public EditModel(AlquilerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Inquilino  Inquilino { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inquilinos == null)
            {
                return NotFound();
            }

            var inquilino = await _context.Inquilinos.FirstOrDefaultAsync(m => m.Id == id);

            if (inquilino == null)
            {
                return NotFound();
            }
            Inquilino = inquilino;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Inquilino).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InquilinoExists(Inquilino.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InquilinoExists(int id)
        {
            return (_context.Inquilinos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}