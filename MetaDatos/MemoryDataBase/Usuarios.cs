 
using Recursos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MetaDatos.MemoryDataBase
{
    public class Usuarios/*: IValidatableObject*/
    { 
         [Display(ResourceType = typeof(Resource), Name = "Usuario_Nombre_Texto_Mostrar")]
        public string NombreUsuario { get; set; }

       
        [Display(ResourceType = typeof(Resource), Name = "Usuario_Password_Texto_Mostrar")]
        public string Password { get; set; }
         

        public static List<Usuarios> ListaUsuarios()
        {
            var ListaUsuarios = new List<Usuarios>
            {
                new Usuarios {NombreUsuario = "Admin", Password ="Admin"},
                new Usuarios {NombreUsuario = "Geronimo", Password = "12345"}


            };


            return ListaUsuarios;
        }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var errores = new List<ValidationResult>();

        //    if (string.IsNullOrEmpty(NombreUsuario))
        //    {
        //        errores.Add(new ValidationResult("El usuario es obligatorio", new string[] { "NombreUsuario" }));
        //    }

        //    if (string.IsNullOrEmpty(Password))
        //    {
        //        errores.Add(new ValidationResult("el password es obligatorio", new string[] { "Password" }));
        //    }

        //    return errores;
        //}
    }
}
