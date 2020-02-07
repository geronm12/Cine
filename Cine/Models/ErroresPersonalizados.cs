using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Models
{
    public class ErroresPersonalizados: ValidationAttribute
    {
        
        public ErroresPersonalizados()
            :base(@"La direccion es obligatoria")
        {
             
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null || (string)value != string.Empty)
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);

                return new ValidationResult(errorMessage);
                
            }

            return ValidationResult.Success;
        }

    }
}
