using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Inquilinos
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
            return Page();
        }

        [BindProperty]
        public Inquilino Inquilino { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Inquilinos == null || Inquilino == null)
            {
                return Page();
            }

            _context.Inquilinos.Add(Inquilino);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}