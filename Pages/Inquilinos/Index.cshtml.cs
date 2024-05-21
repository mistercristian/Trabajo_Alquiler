using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Inquilinos
{
    public class IndexModel : PageModel
    {
        //[Authorize]

        private readonly AlquilerContext _context;

        public IndexModel(AlquilerContext context)
        {
            _context = context;
        }

        public IList<Inquilino> Inquilinos { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Inquilinos != null)
            {
                Inquilinos = await _context.Inquilinos.ToListAsync();
            }
        }
    }
}