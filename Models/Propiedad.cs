using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Propiedad
    {
        [Key]
        public int Idpropiedad { get; set; }
        public string? Direccion { get; set; }
        public string Tipo_propiedad { get; set; }
        public int No_habitaciones { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Precio_alquiler { get; set; }
        public string? Disponible { get; set; }
        
    }
}
