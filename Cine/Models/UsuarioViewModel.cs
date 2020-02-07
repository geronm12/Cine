using Cine.Models.Enumeradores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cine.Models
{
    public class UsuarioViewModel: IValidatableObject
    {
         public string NombreUsuario { get; set; }

         public string Password { get; set; }
         
         public TipoUsuario Tipo { get; set; }
         
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errores = new List<ValidationResult>();

            if(string.IsNullOrEmpty(NombreUsuario))
            {
                errores.Add(new ValidationResult("El usuario es obligatorio", new string[] { "NombreUsuario" }));
            }

            if(string.IsNullOrEmpty(Password))
            {
                errores.Add(new ValidationResult("El password es obligatorio", new string[] { "Password" }));
            }

            return errores;
        }
    }
}
