using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Pago
    {
        [Key]
        public int Id { get; set; }
        public int ContratoId { get; set; }
        public Contrato Contrato { get; set; }

        public DateTime FechaPago { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }
}
