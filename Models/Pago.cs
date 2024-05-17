using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Pago
    {
        [Key]
        public int Idpago { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha_Pago { get; set; }
        [Column(TypeName = "decimal(6,2)")]
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public int ContratosId { get; set; }
        public Contrato? Contratos { get; set; } = default!;
    }
}
