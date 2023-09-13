using System.ComponentModel.DataAnnotations;

namespace WebApiAutores.DTOs
{
    public class CrearRestriccionesIPDTO
    {
        [Required]
        public int LlaveId { get; set; }
        
        [Required]
        public string IP { get; set; }
    }
}
