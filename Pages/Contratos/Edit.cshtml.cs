using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Contratos
{
    public class EditModel : PageModel
    {
        private readonly AlquilerContext _context;

        public EditModel(AlquilerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Contrato Contrato { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contratos.FirstOrDefaultAsync(m => m.Id == id);

            if (contrato == null)
            {
                return NotFound();
            }
            Contrato = contrato;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Contrato).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContratoExists(Contrato.Id))
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

        private bool ContratoExists(int id)
        {
            return (_context.Contratos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

