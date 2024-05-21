using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        public int PropiedadId { get; set; }
        public Propiedad? Propiedad { get; set; }
        public int InquilinoId { get; set; }
        public Inquilino? Inquilino { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaInicio { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaFin { get; set; }
        [Column(TypeName = "decimal(8,2)")]
        public decimal Deposito { get; set; }
        public string Terminos { get; set; }

        public ICollection<Pago>? Pagos { get; set; }


    }
}
