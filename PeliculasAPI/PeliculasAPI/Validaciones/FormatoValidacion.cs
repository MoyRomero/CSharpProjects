using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class FormatoValidacion:ValidationAttribute
    {
        private readonly string[] formatosValidos;

        public FormatoValidacion(string[] FormatosValidos)
        {
            formatosValidos = FormatosValidos;
        }

        public FormatoValidacion(GrupoTipoArchivo grupoTipoArchivo)
        {
            if (grupoTipoArchivo == GrupoTipoArchivo.Imagen) 
                formatosValidos = new string[] { "image/jpg", "image/jpeg", "image/png","image/gif" };
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool formatoEsValido = false;

            if (value == null)
                return ValidationResult.Success;

            IFormFile formFile = value as IFormFile;

            if (formFile == null) return ValidationResult.Success;
            
            for(int i = 0; i < formatosValidos.Length; i++)
                if (formFile.ContentType == formatosValidos[i]) formatoEsValido = true;

            if(!formatoEsValido) 
                return new ValidationResult($"El formato del archivo para el campo Foto, debe ser del tipo: {string.Join(", ", formatosValidos)}");
            
            return ValidationResult.Success;
        }
    }
}
