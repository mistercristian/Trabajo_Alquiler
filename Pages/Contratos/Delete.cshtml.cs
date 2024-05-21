using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Contratos
{
    public class DeleteModel : PageModel
    {
        private readonly AlquilerContext _context;

        public DeleteModel(AlquilerContext context)
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
            else
            {
                Contrato = contrato;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contratos == null)
            {
                return NotFound();
            }
            var contrato = await _context.Contratos.FindAsync(id);

            if (contrato != null)
            {
                Contrato = contrato;
                _context.Contratos.Remove(Contrato);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
