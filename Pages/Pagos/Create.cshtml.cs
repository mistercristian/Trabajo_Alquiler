using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Pagos
{
    public class CreateModel : PageModel
    {
        private readonly AlquilerContext _context;
        public CreateModel(AlquilerContext context)
        {

            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Pago Pago { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Pagos == null || Pago == null)
            {
                ViewData["ContratoId"] = new SelectList(_context.Contratos, "Id", "Id");
                return Page();
            }
            _context.Pagos.Add(Pago);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
