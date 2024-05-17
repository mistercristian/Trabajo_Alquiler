using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Inquilino
    {
        [Key]
        public int Idinquilino { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public string? Email { get; set; }
        public int PropiedadesId { get; set; }
        public Propiedad? Propiedades { get; set; } = default!;
        

    }
}
