using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.DTOs
{
    public class EditarRolDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
