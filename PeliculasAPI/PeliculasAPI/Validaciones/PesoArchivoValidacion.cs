using System.ComponentModel.DataAnnotations;

namespace PeliculasAPI.Validaciones
{
    public class PesoArchivoValidacion:ValidationAttribute
    {
        private readonly int pesoMaximoMB;

        public PesoArchivoValidacion(int PesoMaximoMB)
        {
            pesoMaximoMB = PesoMaximoMB;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;
           
            IFormFile formFile = value as IFormFile;

            if (formFile == null) return ValidationResult.Success;

            if(formFile.Length > pesoMaximoMB * 1024 * 1024)
                return new ValidationResult($"El peso máximo del archivo, no debe superar los {pesoMaximoMB} MB.");

            return ValidationResult.Success;
        }
    }
}
