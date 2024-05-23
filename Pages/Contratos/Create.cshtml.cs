using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Contratos
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
            ViewData["InquilinoId"] = new SelectList(_context.Inquilinos, "Id", "Nombre");
            ViewData["PropiedadId"] = new SelectList(_context.Propiedades, "Id", "Id");
            return Page();

            
        }

        [BindProperty]
        public Contrato Contrato { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Contratos == null || Contrato == null)
            {
                ViewData["InquilinoId"] = new SelectList(_context.Inquilinos, "Id");
                ViewData["PropiedadId"] = new SelectList(_context.Propiedades, "Id", "Id");
                return Page();
            }
            _context.Contratos.Add(Contrato);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

