using System.ComponentModel.DataAnnotations;

namespace Entidades.Validacao
{
    public class LetraMaiusculaAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(value.ToString())) 
                 return ValidationResult.Success;

            string primeiraLetra = value.ToString()[0].ToString();
            if (primeiraLetra != primeiraLetra.ToUpper())
                return new ValidationResult("A primeira letra do nome deve ser Maiuscula");

            return ValidationResult.Success;
        }
    }
}
