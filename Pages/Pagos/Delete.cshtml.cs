using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Pagos
{
    public class DeleteModel : PageModel
    {
        private readonly AlquilerContext _context;

        public DeleteModel(AlquilerContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Pago Pago { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos.FirstOrDefaultAsync(m => m.Id == id);

            if (pago == null)
            {
                return NotFound();
            }
            else
            {
                Pago = pago;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }
            var pago = await _context.Pagos.FindAsync(id);

            if (pago != null)
            {
                Pago = pago;
                _context.Pagos.Remove(Pago);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
