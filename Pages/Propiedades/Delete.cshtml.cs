using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Propiedades
{
    public class DeleteModel : PageModel
    {
        private readonly AlquilerContext _context;

        public DeleteModel(AlquilerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Propiedad Propiedad { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedad = await _context.Propiedades.FirstOrDefaultAsync(m => m.Id == id);

            if (propiedad == null)
            {
                return NotFound();
            }
            else
            {
                Propiedad = propiedad;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }
            var propiedad = await _context.Propiedades.FindAsync(id);

            if (propiedad != null)
            {
                Propiedad = propiedad;
                _context.Propiedades.Remove(Propiedad);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
