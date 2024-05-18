using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trabajo_Alquiler.Models
{
    public class Inquilino
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }

        public int PropiedadId { get; set; }
        public Propiedad Propiedad { get; set; }
        public ICollection<Contrato> Contratos { get; set; }


    }
}
