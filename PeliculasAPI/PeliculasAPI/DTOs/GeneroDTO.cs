using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PeliculasAPI.DTOs
{
    public class GeneroDTO
    {
        [NotMapped]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
