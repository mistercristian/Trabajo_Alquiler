using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Propiedad
    {
        [Key]
        public int Id { get; set; }
        public string? Direccion { get; set; }
        public string? TipoPropiedad { get; set; }
        public int? NumeroHabitaciones { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal? PrecioAlquiler { get; set; }
        public bool Disponible { get; set; }

        public ICollection<Inquilino>? Inquilinos { get; set; }
        public ICollection<Contrato>? Contratos { get; set; }

    }
}
