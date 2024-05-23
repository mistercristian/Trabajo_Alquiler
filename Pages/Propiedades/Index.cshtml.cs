using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trabajo_Alquiler.Data;
using Trabajo_Alquiler.Models;

namespace Trabajo_Alquiler.Pages.Propiedades
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        private readonly AlquilerContext _context;

        public IndexModel(AlquilerContext context)
        {
            _context = context;
        }

        public IList<Propiedad> Propiedades { get; set; } = default!;
        public async Task OnGetAsync()
        {
            if (_context.Propiedades != null)
            {
                Propiedades = await _context.Propiedades.ToListAsync();
            }
        }
    }
}