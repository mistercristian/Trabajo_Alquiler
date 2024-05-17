using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Contrato
    {
        [Key]
        public int Idcontrato { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Inicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha_Fin { get; set; }

        [Column(TypeName = "decimal(6,2)")]
        public decimal Deposito { get; set; }
        public string? Terminos { get; set; }
        public int PropiedadesId { get; set; }
        public Propiedad Propiedades { get; set; } 
        public int InquilinosId { get; set; }
        public Inquilino Inquilinos { get; set; }
        

    }
}
